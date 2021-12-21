using CarpetAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.DataAccess.Abstract
{
    public interface ICompanyRepository :IRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithBranchsAsync();
        Task<Company> GetWithBranchsByIdAsync(int id);
    }
}
