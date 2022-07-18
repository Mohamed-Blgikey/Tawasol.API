using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.Helper
{
    public class AuthModel
    {
        public string FullName { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpire { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
