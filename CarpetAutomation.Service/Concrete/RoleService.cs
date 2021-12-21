using CarpetAutomation.Entities.Model;
using CarpetAutomation.Entities.Repositories;
using CarpetAutomation.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AppRole> CreateRole(AppRole newRole)
        {
            await _unitOfWork.Roles.AddAsync(newRole);
            await _unitOfWork.CommitAsync();
            return newRole;
        }

        public Task DeleteRole(AppRole role)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppRole>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<AppRole> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRole(AppRole roleToBeUpdated, AppRole role)
        {
            throw new NotImplementedException();
        }
    }
}
