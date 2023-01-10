using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BongOliver.API.Services.UserService;
using BongOliver.API.Services.AuthService;
using BongOliver.API.Services.TokenService;
using Microsoft.AspNetCore.Mvc;
using BongOliver.API.DTOs.UserDTO;

namespace BongOliver.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                return Ok(_authService.Register(registerUserDto));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] AuthUserDto authUserDto)
        {
            try
            {
                return Ok(_authService.Login(authUserDto));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            };
        }
    }
}