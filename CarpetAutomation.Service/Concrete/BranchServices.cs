using CarpetAutomation.Entities;
using CarpetAutomation.Entities.Repositories;
using CarpetAutomation.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Concrete
{
    public class BranchServices : IBranchServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public BranchServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Branch> CreateBranch(Branch newBranch)
        {
            await _unitOfWork.Branchs.AddAsync(newBranch);
            return newBranch;
        }

        public async Task DeleteBranch(Branch branch)
        {
            _unitOfWork.Branchs.Remove(branch);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllWithCompany()
        {
            return await _unitOfWork.Branchs.GetAllWithCompanyAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _unitOfWork.Branchs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Branch>> GetBranchsByCompanyId(int companyId)
        {
            return await _unitOfWork.Branchs.GetAllWithCompanyByCompanyIdAsync(companyId);
        }

        public async Task UpdateBranch(Branch branchToBeUpdated, Branch branch)
        {
            branchToBeUpdated.Name = branch.Name;
            branchToBeUpdated.CompanyId = branch.CompanyId;
            await _unitOfWork.CommitAsync();
        }
    }
}
