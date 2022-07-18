using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.DAL.Extend;

namespace Tawasol.DAL.Entity
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
