using CarpetAutomation.DataAccess.Abstract;
using CarpetAutomation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.DataAccess.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(CarpetDBContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Branch>> GetAllWithCompanyAsync()
        {
            return await CarpetDBContext.Branches.Include(w=>w.Company).ToListAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllWithCompanyByCompanyIdAsync(int companyId)
        {
            return await CarpetDBContext.Branches.Include(m => m.Company).Where(m => m.CompanyId == companyId).ToListAsync();
        }

        public async  Task<Branch> GetWithCompanyByIdAsync(int id)
        {
            return await CarpetDBContext.Branches.Include(w => w.Company).SingleOrDefaultAsync(w => w.Id == id);
        }
        private CarpetDBContext CarpetDBContext
        {
            get { return Context as CarpetDBContext; }
        }

        
    }
}
