using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.DTOs
{
    public class UserForReturnDto
    {
        public string FullName { get; set; }
        public bool Gender { get; set; }

        public DateTime CreatedAt { get; set; }

        public string PhotoUrl { get; set; } = "https://res.cloudinary.com/dz0g6ou0i/image/upload/v1654960873/defualt_w4v99c.png";
        public string CoverUrl { get; set; } = "https://res.cloudinary.com/dz0g6ou0i/image/upload/v1654960873/defualt_w4v99c.png";
        public List<PhotoForReturnDto> ProfilePhotos { get; set; }
        public List<PhotoForReturnDto> CoverPhotos { get; set; }
    }
}
