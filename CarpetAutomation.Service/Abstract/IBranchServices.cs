using CarpetAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Abstract
{
    public interface IBranchServices
    {
        Task<IEnumerable<Branch>> GetAllWithCompany();
        Task<Branch> GetBranchById(int id);
        Task<IEnumerable<Branch>> GetBranchsByCompanyId(int companyId);
        Task<Branch> CreateBranch(Branch newBranch);
        Task UpdateBranch(Branch branchToBeUpdated, Branch branch);
        Task DeleteBranch(Branch branch);
    }
}
