using BongOliver.API.DTOs.UserDTO;

namespace BongOliver.API.Services.UserService
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto? GetUserByUsername(string username);
        // string RegisterUser (RegisterUserDto registerUserDto);
        // string Login(AuthUserDto authUserDto);
        void UpdateUser (UserUpdateDto userUpdateDto, string username);
        void DeleteUser (string username);
        bool IsSaveChanges();
    }
}
