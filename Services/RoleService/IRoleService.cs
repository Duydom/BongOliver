using BongOliver.API.DTOs.RoleDTO;

namespace BongOliver.API.Services.RoleService
{
    public interface IRoleService
    {
        List<RoleDto> GetRoles();
        // RoleDto? GetRoleById(int id);
        // bool IsSaveChanges();
    }
}
