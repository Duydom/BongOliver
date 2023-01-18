using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BongOliver.API.Database.Entities;

namespace BongOliver.API.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        string GetRoleById(int id);
        // Role GetRoleByRolename(string Rolename);
        // void CreateRole(Role Role);
        // void UpdateRole(Role Role);
        // void DeleteRole(Role Role);
        bool IsSaveChanges();
    }
}