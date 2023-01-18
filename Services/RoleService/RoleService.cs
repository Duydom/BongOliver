using AutoMapper;
using AutoMapper.QueryableExtensions;
using BongOliver.API.Database;
using BongOliver.API.DTOs.RoleDTO;
using BongOliver.API.Repositories;
using System.Security.Cryptography;
using System.Text;
using BongOliver.API.Services.TokenService;

namespace BongOliver.API.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;
        private readonly IRoleRepository _roleRepository;

        // private readonly IMapper _mapper;
        public RoleService(DataContext context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        public List<RoleDto> GetRoles()
        {
            var rolesDto = new List<RoleDto>();
            var roles = _roleRepository.GetRoles();
            foreach (var role in roles) 
            {
                rolesDto.Add(new RoleDto()
                    {
                        id = role.id,
                        name = role.name
                    }
                );
            }
            return rolesDto;
        }

        // public bool IsSaveChanges()
        // {
        //     return _roleRepository.IsSaveChanges();
        // }
    }
}