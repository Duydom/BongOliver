using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BongOliver.API.Services.AuthService;
using BongOliver.API.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using BongOliver.API.DTOs.UserDTO;
using Microsoft.AspNetCore.Authorization;

namespace BongOliver.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpGet("users")]
        public ActionResult<IEnumerable<UserDto>> GetAllUser()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("users/{username}")]
        public ActionResult<UserDto> GetUserByUsername(string username)
        {
            if(_userService.GetUserByUsername(username) == null) return NotFound();
            else
            return Ok(_userService.GetUserByUsername(username));
        }

        [HttpPut("users/{username}")]
        public IActionResult UpdateUser(string username, [FromBody] UserUpdateDto userUpdateDto)
        {
            _userService.UpdateUser(userUpdateDto,username);
            if (_userService.IsSaveChanges()) return Ok("Update success!");
            else return BadRequest("Update faile!");
        }

        [Authorize]
        [HttpDelete("users/{username}")]
        public IActionResult DeleteUser(string username)
        {
            _userService.DeleteUser(username);
            if (_userService.IsSaveChanges()) return Ok("Delete success!");
            else return BadRequest("Delete faile!");
        }
    }
}