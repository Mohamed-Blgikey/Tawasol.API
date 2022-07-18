using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.BL.Interface;
using Tawasol.DAL.Database;
using Tawasol.DAL.Entity;

namespace Tawasol.BL.Repository
{
    public class CoverRep: BaseRep<CoverPhoto>, ICoverRep
    {
        private readonly AppDbContext context;

        public CoverRep(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public void UpdateRange(IEnumerable<CoverPhoto> coverPhotos)
        {
            context.UpdateRange(coverPhotos);
        }
    }
}
