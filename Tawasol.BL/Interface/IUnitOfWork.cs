using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.DAL.Entity;
using Tawasol.DAL.Extend;

namespace Tawasol.BL.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRep<AppUser> Users { get; }

        IProfilePhotoRep ProfilePhotos { get; }
        ICoverRep CoverPhotos { get; }
        //IBaseRep<CoverPhoto> CoverPhotos { get; }
        Task<int> CompleteAsync();
    }
}
