using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.BL.DTOs;
using Tawasol.DAL.Entity;
using Tawasol.DAL.Extend;

namespace Tawasol.BL.Helper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<AppUser, UserForReturnDto>()
              .ForMember(dest => dest.PhotoUrl, opt => { opt.MapFrom(p => p.ProfilePhotos.FirstOrDefault(a => a.IsMain).Url); })
              .ForMember(dest => dest.CoverUrl, opt => { opt.MapFrom(p => p.CoverPhotos.FirstOrDefault(a => a.IsMain).Url); });

            CreateMap<CreatePhotoDto, ProfilePhoto>();
            CreateMap<CreatePhotoDto, CoverPhoto>();

            CreateMap<PhotoForReturnDto, ProfilePhoto>();
            CreateMap<PhotoForReturnDto, CoverPhoto>();


            CreateMap<ProfilePhoto, PhotoForReturnDto>();
            CreateMap<CoverPhoto, PhotoForReturnDto>();

        }
    }
}
