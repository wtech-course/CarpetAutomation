using CarpetAutomation.DataAccess.Abstract;
using CarpetAutomation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.DataAccess.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(CarpetDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Company>> GetAllWithBranchsAsync()
        {
            return (IEnumerable<Company>)await CarpetDBContext.Companies.Include(a => a.Branchs).SingleOrDefaultAsync();
        }

        public Task<Company> GetWithBranchsByIdAsync(int id)
        {
            return CarpetDBContext.Companies.Include(a => a.Branchs).SingleOrDefaultAsync(a => a.Id == id);
        }
        private CarpetDBContext CarpetDBContext
        {
            get { return Context as CarpetDBContext; }
        }


    }
}
