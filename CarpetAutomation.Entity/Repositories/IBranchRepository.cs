using CarpetAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.DataAccess.Abstract
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetAllWithCompanyAsync();
        Task<Branch> GetWithCompanyByIdAsync(int id);
        Task<IEnumerable<Branch>> GetAllWithCompanyByCompanyIdAsync(int companyId);
    }
}
