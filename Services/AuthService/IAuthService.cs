using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BongOliver.API.DTOs.UserDTO;

namespace BongOliver.API.Services.AuthService
{
    public interface IAuthService
    {
        string Login(AuthUserDto authUserDto);
        string Register(RegisterUserDto registerUserDto);
    }
}