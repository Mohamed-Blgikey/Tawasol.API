using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.DTOs
{
    public class CreatePhotoDto
    {
        public IFormFile File { get; set; }
        public string? Url { get; set; }
        public string? PublicId { get; set; }
        public bool IsMain { get; set; } = false;



        public string UserId { get; set; }

        public string Type { get; set; }
    }
}
