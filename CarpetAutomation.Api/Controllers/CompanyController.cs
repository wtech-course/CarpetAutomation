using CarpetAutomation.Api.Helpers;
using CarpetAutomation.Entities;
using CarpetAutomation.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarpetAutomation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;
        public CompanyController(ICompanyServices companyServices)
        {
            this._companyServices = companyServices;
        }

        [HttpGet("[action]")]
        public async Task<Response<IEnumerable<Company>>> GetAllData()
        {
           var company= await _companyServices.GetAllCompanies();
            return new Response<IEnumerable<Company>>().Ok( company.Count(),company);
        }
        [HttpPost("GetAllCompanies")]
        public async Task<Response<IEnumerable<Company>>> GetAllCompanies()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                //var companies = await _companyServices.GetAllCompanies();
                var customerData = (from tempcustomer in await _companyServices.GetAllCompanies() select tempcustomer);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(s => s.CompanyName == (sortColumn + " " + sortColumnDirection));
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Id.ToString().Contains(searchValue)
                                                || m.CompanyName.Contains(searchValue)
                                                || m.CompanyNumber.ToString().Contains(searchValue)
                                                || m.Address.Contains(searchValue));
                }
                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                //return Ok(jsonData);
                return new Response<IEnumerable<Company>>().Ok(customerData.Count(), customerData);
            }
            catch (Exception ex)
            {
                throw;
            }
         

        }

        [HttpPost("[action]")]
        public async Task<Response<Company>> Create(Company company)
        {

            try
            {
                if (company.Id==0)
                await _companyServices.CreateCompany(company);
                else await _companyServices.UpdateCompany(company);
                return new Response<Company>().Ok(1, company);
            }
            catch (Exception ex)
            {
                return new Response<Company>().Error(1, company,ex.ToString());
            }
        }

        [HttpPost("[action]/{id}")]
        public async Task Delete(int id)
        {
            if (id != 0)
            {
                var deleteData = await _companyServices.GetCompanyById(id);

                await _companyServices.DeleteCompany(deleteData);
            }


        }

        //[HttpPost("[action]")]
        //public async Task<Response<Company>> Update(Company companyUpdated, Company company)
        //{
        //    try
        //    {
        //        await _companyServices.UpdateCompany(companyUpdated, company);
        //        return new Response<Company>().Ok(1, company);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<Company>().Error(1, company, ex.ToString());
        //    }
        //}




    }
}
