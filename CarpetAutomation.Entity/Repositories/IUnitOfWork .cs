using CarpetAutomation.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBranchRepository Branchs { get; }
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task<int> CommitAsync();
    }
}
