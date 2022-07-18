using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.DTOs
{
    public class RegisterDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
    }
}
