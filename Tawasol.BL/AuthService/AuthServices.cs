using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tawasol.BL.DTOs;
using Tawasol.BL.Helper;
using Tawasol.BL.Interface;
using Tawasol.DAL.Extend;

namespace Tawasol.BL.AuthService
{
    public class AuthServices : IAuthServices
    {
        #region fields
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOptions<JWT> jwt;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly MailSettings _mailSettings;

        #endregion

        #region Ctor
        public AuthServices(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IOptions<JWT> jwt, RoleManager<IdentityRole> roleManager, IOptions<MailSettings> mailSettings)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.jwt = jwt;
            this.roleManager = roleManager;
            _mailSettings = mailSettings.Value;
        }

        #endregion

        #region Login
        public async Task<AuthModel> Login(LoginDto loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, loginDTO.Password))
                return new AuthModel { Message = "Inavlid Email Or Password" };

            if (user.EmailConfirmed == false)
            {
                return new AuthModel { Message = "Please Check Your Inbox To Confirm Email First" };
            }


            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Message = "success",
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                TokenExpire = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                FullName = user.FullName
            };
        }
        #endregion

        #region Register

        public async Task<AuthModel> Register(RegisterDto registerDTO)
        {
            try
            {
                if (await userManager.FindByEmailAsync(registerDTO.Email) != null)
                    return new AuthModel { Message = "Email Is Already Token" };
                var user = new AppUser
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.Email,
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Gender = registerDTO.Gender,
                };
                var result = await userManager.CreateAsync(user, registerDTO.Password);

                if (!result.Succeeded)
                {
                    var error = string.Empty;
                    foreach (var item in result.Errors)
                    {
                        error += $"{item.Description},";
                    }
                    return new AuthModel { Message = error };
                }

                var RoleExsit = await roleManager.RoleExistsAsync("Admin");
                if (!RoleExsit)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    if (!await roleManager.RoleExistsAsync("User"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("User"));
                    }
                    await userManager.AddToRoleAsync(user, "User");
                }

                var jwtSecurityToken = await CreateJwtToken(user);


                return new AuthModel
                {
                    Message = "success",
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    TokenExpire = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    FullName = user.FullName

                };
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion


        #region SendEmail
        public async Task SendEmailAsync(string mailTo, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = subject
            };

            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();


            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }

        #endregion

        #region Confime Email
        public async Task<AuthModel> ConfirmEmail(ConfirmEmailDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return new AuthModel
                {
                    Message = "error"
                };
            }
            if (user.EmailConfirmed == true)
            {
                return new AuthModel
                {
                    Message = "Email already confirmed "
                };
            }
            var data = new JwtSecurityTokenHandler().ReadJwtToken(dto.Token); ;
            foreach (var claim in data.Claims)
            {
                if (claim.Value == dto.Email)
                {
                    user.EmailConfirmed = true;
                    await userManager.UpdateAsync(user);
                    return new AuthModel
                    {
                        Message = "Confirmed Done !"
                    };
                }
            }
            return new AuthModel
            {
                Message = "error"
            };
        }

        #endregion

        #region Forget Pass
        public async Task<AuthModel> ForgetPass(ForgetPassDto dTO)
        {
            var user = await userManager.FindByEmailAsync(dTO.Email);
            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                return new AuthModel
                {
                    Message = "success",
                    Token = token
                };
            }

            return new AuthModel
            {
                Message = "error"
            };

        }
        #endregion

        #region ResetPass
        public async Task<AuthModel> ResetPass(ResetPassDto dTO)
        {
            var user = await userManager.FindByEmailAsync(dTO.Email);
            if (user == null)
            {
                return new AuthModel { Message = "error" };
            }

            var result = await userManager.ResetPasswordAsync(user, dTO.Token, dTO.Password);
            if (!result.Succeeded)
            {
                return new AuthModel { Message = "error" };
            }
            return new AuthModel
            {
                Message = "You password has been updated ^_^ ",
            };
        }
        #endregion

        #region Create Token
        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var Photo = await unitOfWork.ProfilePhotos.FindAsync(p => p.UserId == user.Id && p.IsMain == true);
            string PhotoUrl = Photo == null ? "https://res.cloudinary.com/dz0g6ou0i/image/upload/v1654960873/defualt_w4v99c.png" : Photo.Url;
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            List<Claim> roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("fullName", user.FullName),
                new Claim("photoUrl", PhotoUrl),

            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Value.Issuer,
                audience: jwt.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwt.Value.DurationInDays),
                signingCredentials: signingCredentials);



            return jwtSecurityToken;


        }


        #endregion
    }
}
