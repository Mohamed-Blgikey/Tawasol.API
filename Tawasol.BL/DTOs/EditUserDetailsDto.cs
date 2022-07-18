using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.DTOs
{
    public class EditUserDetailsDto
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool Gender { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Instagram { get; set; }
        public string? WhatsApp { get; set; }
        public string? SocialSituationnstagram { get; set; }

    }
}
