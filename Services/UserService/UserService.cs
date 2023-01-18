using AutoMapper;
using AutoMapper.QueryableExtensions;
using BongOliver.API.Database;
using BongOliver.API.DTOs.UserDTO;
using BongOliver.API.Repositories;
using System.Security.Cryptography;
using System.Text;
using BongOliver.API.Services.TokenService;

namespace BongOliver.API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;

        // private readonly IMapper _mapper;
        public UserService(DataContext context, IUserRepository userRepository, ITokenService tokenService, IRoleRepository roleRepository)
        {
            // _mapper = mapper;
            _context = context;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _roleRepository = roleRepository;
        }
        public UserDto GetUserByUsername(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) return null;
            var userDto = new UserDto()
            {
                id = user.id,
                firstname = user.firstname,
                lastname = user.lastname,
                image = user.image,
                gender = user.gender,
                dateOfBirth = user.dateOfBirth,
                username = user.username,
                phoneNumber = user.phoneNumber,
                role = _roleRepository.GetRoleById(user.role_id),
                createAt = user.createAt,
                updateAt = user.updateAt
            };

            return userDto;
        }

        public List<UserDto> GetUsers()
        {
            var usersDto = new List<UserDto>();
            var users = _userRepository.GetUsers();
            foreach (var user in users) 
            {
                usersDto.Add(new UserDto()
                    {
                        id = user.id,
                        firstname = user.firstname,
                        lastname = user.lastname,
                        image = user.image,
                        gender = user.gender,
                        dateOfBirth = user.dateOfBirth,
                        username = user.username,
                        phoneNumber = user.phoneNumber,
                        role = _roleRepository.GetRoleById(user.role_id),
                        createAt = user.createAt,
                        updateAt = user.updateAt
                    }
                );
            }
            return usersDto;
        }
        public void DeleteUser(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) return;
            _userRepository.DeleteUser(user);
        }

        public void UpdateUser(UserUpdateDto userUpdateDto, string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) return;
            user.firstname = userUpdateDto.firstname;
            user.lastname = userUpdateDto.lastname;
            user.image = userUpdateDto.image;
            user.gender = userUpdateDto.gender;
            user.dateOfBirth = userUpdateDto.dateOfBirth;
            user.phoneNumber = userUpdateDto.phoneNumber;
            user.updateAt = DateTime.Now;
            _userRepository.UpdateUser(user);
        }

        public bool IsSaveChanges()
        {
            return _userRepository.IsSaveChanges();
        }
    }
}