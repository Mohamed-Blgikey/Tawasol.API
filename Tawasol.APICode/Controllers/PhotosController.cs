using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Tawasol.BL.DTOs;
using Tawasol.BL.Helper;
using Tawasol.BL.Interface;
using Tawasol.DAL.Entity;

namespace Tawasol.APICode.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PhotosController : ControllerBase
    {
        #region field
        private readonly IOptions<ClodinarySettings> clodinarySettings;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private Cloudinary _cloudinary;
        #endregion

        #region ctor
        public PhotosController(IOptions<ClodinarySettings> clodinarySettings, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.clodinarySettings = clodinarySettings;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Account account = new Account(clodinarySettings.Value.CloudName, clodinarySettings.Value.ApiKey, clodinarySettings.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }
        #endregion

        #region Actions


        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImageProfile([FromForm] CreatePhotoDto dto)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId != dto.UserId)
                return Unauthorized();
            try
            {
                //for Image Profile
                if (dto.Type == "p")
                {
                    var uploadResult = await UploadPhoto(dto.File, 400, 400, "face", "fill");

                    var user = await unitOfWork.Users.FindAsync(p => p.Id == userId, new[] { "ProfilePhotos" });

                    if (user.ProfilePhotos.Any(a => a.IsMain))
                    {
                        var oldImage = user.ProfilePhotos.First(i => i.IsMain);
                        oldImage.IsMain = false;
                        unitOfWork.ProfilePhotos.Update(oldImage);
                    }

                    dto.IsMain = true;
                    dto.PublicId = uploadResult.Data;
                    dto.Url = uploadResult.Message;

                    var photo = mapper.Map<ProfilePhoto>(dto);

                    var createResult = await unitOfWork.ProfilePhotos.AddAsync(photo);

                    if (createResult != null)
                    {
                        await unitOfWork.CompleteAsync();

                        return Ok(new ApiResponse<PhotoForReturnDto>
                        {
                            Code = 200,
                            Status = "ok",
                            Message = "success",
                            Data = mapper.Map<PhotoForReturnDto>(createResult),
                        });
                    }
                }
                //for Cover
                else if (dto.Type == "c")
                {
                    var uploadResult = await UploadPhoto(dto.File, 14000, 1600, "faces", "crop");

                    var user = await unitOfWork.Users.FindAsync(p => p.Id == userId, new[] { "CoverPhotos" });

                    if (user.CoverPhotos.Any(a => a.IsMain))
                    {
                        var oldImage = user.CoverPhotos.First(i => i.IsMain);
                        oldImage.IsMain = false;
                        unitOfWork.CoverPhotos.Update(oldImage);
                    }

                    dto.IsMain = true;
                    dto.PublicId = uploadResult.Data;
                    dto.Url = uploadResult.Message;

                    var photo = mapper.Map<CoverPhoto>(dto);

                    var createResult = await unitOfWork.CoverPhotos.AddAsync(photo);

                    if (createResult != null)
                    {
                        await unitOfWork.CompleteAsync();

                        return Ok(new ApiResponse<PhotoForReturnDto>
                        {
                            Code = 200,
                            Status = "ok",
                            Message = "success",
                            Data = mapper.Map<PhotoForReturnDto>(createResult),
                        });
                    }
                }
                //for Posts
                else
                {

                }

                return Ok(new ApiResponse<string>
                {
                    Code = 404,
                    Status = "not found",
                    Message = "server error"
                });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("SetMain/{type}")]
        public async Task<IActionResult> SetMainProfile(string type, PhotoForReturnDto[] dtos)
        {
            if (type == "profile")
            {
                var photos = mapper.Map<IEnumerable<ProfilePhoto>>(dtos);
                unitOfWork.ProfilePhotos.UpdateRange(photos);
            }
            else
            {
                var photos = mapper.Map<IEnumerable<CoverPhoto>>(dtos);
                unitOfWork.CoverPhotos.UpdateRange(photos);
            }
            var status = await unitOfWork.CompleteAsync();
            if (status > 0)
            {
                return Ok(new ApiResponse<IEnumerable<PhotoForReturnDto>>
                {
                    Code = 200,
                    Status = "ok",
                    Message = "success",
                    Data = dtos
                });
            }
            return Ok(new ApiResponse<string>
            {
                Code = 404,
                Status = "not found",
                Message = "error",
            });
        }


        [HttpPost("DeleteImage/{type}")]
        public async Task<IActionResult> DeleteProfileImage(string type, PhotoForReturnDto dto)
        {

            if (type == "profile")
            {
                var photo = mapper.Map<ProfilePhoto>(dto);
                var result = unitOfWork.ProfilePhotos.Delete(photo);
                if (result == null)
                {
                    return Ok(new ApiResponse<string>
                    {
                        Code = 404,
                        Status = "not found",
                        Message = "error",
                    });
                }
                var status = await unitOfWork.CompleteAsync();
                if (status > 0)
                {
                    await DeletePhoto(result.PublicId);
                    return Ok(new ApiResponse<PhotoForReturnDto>
                    {
                        Code = 200,
                        Status = "ok",
                        Message = "success",
                        Data = dto
                    });

                }
            }
            else if (type == "cover")
            {
                var photo = mapper.Map<CoverPhoto>(dto);
                var result = unitOfWork.CoverPhotos.Delete(photo);
                if (result == null)
                {
                    return Ok(new ApiResponse<string>
                    {
                        Code = 404,
                        Status = "not found",
                        Message = "error",
                    });
                }
                var status = await unitOfWork.CompleteAsync();
                if (status > 0)
                {
                    await DeletePhoto(result.PublicId);
                    return Ok(new ApiResponse<PhotoForReturnDto>
                    {
                        Code = 200,
                        Status = "ok",
                        Message = "success",
                        Data = dto
                    });

                }
            }
            //for posts
            else
            {

            }


            return Ok(new ApiResponse<string>
            {
                Code = 404,
                Status = "not found",
                Message = "error",
            });
        }

        [HttpPut("CoverViewEdit")]
        public async Task<IActionResult> CoverViewEdit(PhotoForReturnDto dto)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier).Value != dto.UserId)
            {
                return Unauthorized();
            }
            var cover = mapper.Map<CoverPhoto>(dto);
            var result = unitOfWork.CoverPhotos.Update(cover);
            if (result != null)
            {
                await unitOfWork.CompleteAsync();
                return Ok(new ApiResponse<PhotoForReturnDto>
                {
                    Code = 200,
                    Status = "ok",
                    Message = "success",
                    Data = dto
                });
            }
            return Ok(new ApiResponse<PhotoForReturnDto>
            {
                Code = 404,
                Status = "not found",
                Message = "error",
                Data = dto
            });
        }

        #region Clodinary method
        private async Task<ApiResponse<string>> UploadPhoto(IFormFile file, int W, int H, string G, string C)
        {
            var uploadResult = new ImageUploadResult();
            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation()
                         .Gravity(G)
                    };
                    if (W > 0 && H > 0)
                    {
                        uploadParams.Transformation = new Transformation()
                            .Height(H).Width(W).Crop(C).Gravity(G);
                    }

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }
            if (uploadResult != null)
            {
                return new ApiResponse<string>
                {
                    Message = uploadResult.Url.ToString(),
                    Data = uploadResult.PublicId
                };
            }
            return new ApiResponse<string>
            {
                Message = "error"
            };
        }

        private async Task<string> DeletePhoto(string publicId)
        {


            if (publicId != null)
            {
                var deleteParams = new DeletionParams(publicId);
                var resule = await _cloudinary.DestroyAsync(deleteParams);
                if (resule.Result == "ok")
                {
                    return "deleted";
                }
            }


            return "error";
        }
        #endregion
        #endregion
    }
}
