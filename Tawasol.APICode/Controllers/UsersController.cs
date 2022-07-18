using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tawasol.BL.DTOs;
using Tawasol.BL.Helper;
using Tawasol.BL.Interface;

namespace Tawasol.APICode.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        #region fields
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Ctor
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion


        #region Actions


        [HttpGet("Get/{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await unitOfWork.Users.FindAsync(u => u.Id == id, new[] { "ProfilePhotos", "CoverPhotos" });
            if (user == null)
            {
                return Ok(new { message = $"user not found with id => {id}" });
            }
            var returnUser = mapper.Map<UserForReturnDto>(user);
            return Ok(new ApiResponse<UserForReturnDto>
            {
                Code = 200,
                Status = "ok",
                Message = "success",
                Data = returnUser
            });
        }
        #endregion
    }
}
