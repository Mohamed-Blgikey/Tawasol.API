using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.BL.Interface;
using Tawasol.DAL.Database;
using Tawasol.DAL.Entity;
using Tawasol.DAL.Extend;

namespace Tawasol.BL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IBaseRep<AppUser> Users { get; private set; }
        //public IBaseRep<CoverPhoto> CoverPhotos { get; private set; }

        public IProfilePhotoRep ProfilePhotos { get; private set; }
        public ICoverRep CoverPhotos { get; private set; }


        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Users = new BaseRep<AppUser>(context);
            ProfilePhotos = new ProfilePhotoRep(context);
            CoverPhotos = new CoverRep(context);
        }



        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
