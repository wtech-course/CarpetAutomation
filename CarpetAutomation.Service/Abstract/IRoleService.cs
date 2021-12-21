using CarpetAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Abstract
{
    public interface IRoleService
    {
        Task<IEnumerable<AppRole>> GetAllRoles();
        Task<AppRole> GetRoleById(int id);
        Task<AppRole> CreateRole(AppRole newRole);
        Task UpdateRole(AppRole roleToBeUpdated, AppRole role);
        Task DeleteRole(AppRole role);
    }
}
