using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
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
        private readonly IHubContext<UsersHub> usersHub;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Ctor
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper,IHubContext<UsersHub> usersHub)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.usersHub = usersHub;
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

        
        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser(EditUserDetailsDto dto)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier).Value != dto.Id)
            {
                return Unauthorized();
            }
            var user = await unitOfWork.Users.FindAsync(u => u.Id == dto.Id);
            user.FirstName = dto.firstName;
            user.LastName = dto.lastName;
            user.Gender = dto.Gender;
            user.City = dto.City;
            user.Country = dto.Country;
            user.Instagram = dto.Instagram;
            user.SocialSituationnstagram = dto.SocialSituationnstagram;
            user.PhoneNumber = dto.WhatsApp;
            user.Work = dto.Work;
            user.Graduated = dto.Graduated;

            var result = unitOfWork.Users.Update(user);
            if (result == null)
            {
                return Ok(new ApiResponse<EditUserDetailsDto>
                {
                    Code = 404,
                    Status = "not found",
                    Message = "error",
                    Data = dto
                });
            }
            await unitOfWork.CompleteAsync();
            var userForReturn = mapper.Map<UserForReturnDto>(user);
            await usersHub.Clients.All.SendAsync("EditDetails", userForReturn);
            return Ok(new ApiResponse<UserForReturnDto>
            {
                Code = 200,
                Status = "ok",
                Message = "success",
                Data = userForReturn
            });
        }
        #endregion
    }
}
