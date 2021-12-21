using CarpetAutomation.Entities;
using CarpetAutomation.Entities.Repositories;
using CarpetAutomation.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Concrete
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Company> CreateCompany(Company newcompany)
        {
            await _unitOfWork.Companies.AddAsync(newcompany);
            await _unitOfWork.CommitAsync();
            return newcompany;
        }

        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        public async  Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _unitOfWork.Companies.GetAllAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _unitOfWork.Companies.GetByIdAsync(id);
        }

        public async Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            companyToBeUpdated.CompanyName = company.CompanyName;
            await _unitOfWork.CommitAsync();
        }
    }
}
