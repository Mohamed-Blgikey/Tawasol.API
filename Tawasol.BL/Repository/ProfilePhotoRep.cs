using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.BL.Interface;
using Tawasol.DAL.Entity;
using Tawasol.DAL.Database;

namespace Tawasol.BL.Repository
{
    public class ProfilePhotoRep : BaseRep<ProfilePhoto>, IProfilePhotoRep
    {
        private readonly AppDbContext context;

        public ProfilePhotoRep(AppDbContext context):base(context)
        {
            this.context = context;
        }
        public void UpdateRange(IEnumerable<ProfilePhoto> profilePhotos)
        {
            context.UpdateRange(profilePhotos);
        }
    }
}
