using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Tawasol.BL.AuthService;
using Tawasol.BL.DTOs;

namespace Tawasol.APICode.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region fields
        private readonly IAuthServices authservice;

        #endregion

        #region ctor
        public AuthController(IAuthServices authservice)
        {
            this.authservice = authservice;
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await authservice.Login(dto);

            if (!result.IsAuthenticated) { return Ok(new { message = result.Message }); }

            return Ok(new { message = result.Message, token = result.Token, tokenExpire = result.TokenExpire, fullName = result.FullName });
        }
        #endregion

        #region Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authservice.Register(registerDTO);
            if (!result.IsAuthenticated)
                return Ok(new { message = result.Message });

            const string url = "http://localhost:4200/confirmemail";
            var param = new Dictionary<string, string>() { { "email", $"{registerDTO.Email}" }, { "token", $"{result.Token}" } };
            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            await authservice.SendEmailAsync(registerDTO.Email, "Confirm Email", $"{newUrl}");
            return Ok(new { message = result.Message, token = result.Token, expiresOn = result.TokenExpire, fullName = result.FullName });
        }
        #endregion

        #region confirmEmail
        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authservice.ConfirmEmail(dto);
            if (result.Message == "error")
            {
                return Ok(new { message = "pls create acount first" });
            }
            return Ok(new { message = result.Message });
        }
        #endregion

        #region ForgetPass
        [HttpPost("ForgetPass")]
        public async Task<IActionResult> ForgetPass(ForgetPassDto dto)
        {
            var result = await authservice.ForgetPass(dto);
            if (result.Message == "error")
            {
                return Ok(new { message = "pls create account first ^_^ " });
            }

            const string url = "http://localhost:4200/resetpass";
            var param = new Dictionary<string, string>() { { "email", $"{dto.Email}" }, { "token", $"{result.Token}" } };
            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            await authservice.SendEmailAsync(dto.Email, "Reset Your password", $"{newUrl}");

            return Ok(new { message = "pls check your inbox to change password^_^ " });
        }
        #endregion


        #region ResetPass
        [HttpPost("ResetPass")]
        public async Task<IActionResult> ResetPass(ResetPassDto dto)
        {
            var result = await authservice.ResetPass(dto);
            if (result.Message == "error")
            {
                return Ok(new { message = "Some thing Error" });
            }

            return Ok(new { message = result.Message });
        }
        #endregion

    }
}
