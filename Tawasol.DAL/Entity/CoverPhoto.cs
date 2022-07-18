using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.DAL.Extend;

namespace Tawasol.DAL.Entity
{
    public class CoverPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int Width { get; set; }
        public int Heigth { get; set; }
        public int PostionX { get; set; }
        public int PostionY { get; set; }
    }
}
