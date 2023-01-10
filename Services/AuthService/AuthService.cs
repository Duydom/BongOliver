using System.Security.Cryptography;
using System.Text;
// using BongOliver.API.Database;
using BongOliver.API.Database.Entities;

using BongOliver.API.Repositories;
using BongOliver.API.DTOs.UserDTO;
using BongOliver.API.Services.TokenService;

namespace BongOliver.API.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
 
        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
 
        public string Login(AuthUserDto authUserDto)
        {
            authUserDto.username = authUserDto.username.ToLower();
 
            var currentUser = _userRepository.GetUserByUsername(authUserDto.username);
 
            if (currentUser == null)
            {
                throw new UnauthorizedAccessException("Username is invalid.");
            }
 
            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(authUserDto.password)
            );
 
            for (int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if (currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    throw new UnauthorizedAccessException("Password is invalid.");
                }
            }
 
            return _tokenService.CreateToken(currentUser.username);
        }
 
        public string Register(RegisterUserDto registerUserDto)
        {
            registerUserDto.username = registerUserDto.username.ToLower();
            var currentUser = _userRepository.GetUserByUsername(registerUserDto.username);
            if (currentUser != null)
            {
                throw new BadHttpRequestException("Username is already existed!");
            }

            if(registerUserDto.password != registerUserDto.cfpassword)
            {
                throw new BadHttpRequestException("Confirm password is wrong!");
            }

            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(registerUserDto.password);

            var newUser = new User()
                {
                    // id = registerUserDto.id,
                    firstname = registerUserDto.firstname,
                    lastname = registerUserDto.lastname,
                    image = registerUserDto.image,
                    gender = registerUserDto.gender,
                    dateOfBirth = registerUserDto.dateOfBirth,
                    username = registerUserDto.username,
                    phoneNumber = registerUserDto.phoneNumber,
                    role_id = 1,
                    PasswordSalt = hmac.Key,
                    PasswordHash = hmac.ComputeHash(passwordBytes),
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
            var newUser1 = new UserDto();
            _userRepository.CreateUser(newUser);
            if (_userRepository.IsSaveChanges()) return _tokenService.CreateToken(newUser.username);
            else throw new BadHttpRequestException("Register faile!");
        }
    }
}
