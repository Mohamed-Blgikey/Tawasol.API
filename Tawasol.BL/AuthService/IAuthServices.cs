using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.BL.DTOs;
using Tawasol.BL.Helper;

namespace Tawasol.BL.AuthService
{
    public interface IAuthServices
    {
        Task<AuthModel> Register(RegisterDto registerDTO);
        Task<AuthModel> Login(LoginDto loginDTO);

        Task SendEmailAsync(string mailTo, string subject, string body);

        Task<AuthModel> ConfirmEmail(ConfirmEmailDto confirmEmailDTO);
        Task<AuthModel> ForgetPass(ForgetPassDto dTO);
        Task<AuthModel> ResetPass(ResetPassDto dTO);
    }
}
