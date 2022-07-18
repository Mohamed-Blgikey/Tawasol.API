using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.DAL.Entity;

namespace Tawasol.BL.Interface
{
    public interface IProfilePhotoRep:IBaseRep<ProfilePhoto>
    {
        void UpdateRange(IEnumerable<ProfilePhoto> profilePhotos);
    }
}
