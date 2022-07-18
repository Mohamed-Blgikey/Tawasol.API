using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.DTOs
{
    public class ResetPassDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
