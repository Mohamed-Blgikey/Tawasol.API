using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.DAL.Entity;

namespace Tawasol.BL.Interface
{
    public interface ICoverRep : IBaseRep<CoverPhoto>
    {
        void UpdateRange(IEnumerable<CoverPhoto> coverPhotos);
    }
}
