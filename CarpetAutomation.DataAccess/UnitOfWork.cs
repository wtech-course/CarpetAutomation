using CarpetAutomation.DataAccess.Repositories;
using CarpetAutomation.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarpetDBContext _context;
        private BranchRepository _branchRepository;
        private CompanyRepository _companyRepository;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        public UnitOfWork(CarpetDBContext context)
        {
            this._context = context;
        }
        public Abstract.IBranchRepository Branchs => _branchRepository = _branchRepository ?? new BranchRepository(_context);

        public Abstract.ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);

        IRoleRepository IUnitOfWork.Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
