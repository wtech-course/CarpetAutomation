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
        //url/api/company/getallcompanies
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var company = await _companyServices.GetAllCompanies();
            //var data = JsonConvert.SerializeObject(company);
            return Ok(company);
        }

        [HttpPost("[action]")]
        public async Task<Company> Create(Company company)
        {
            await _companyServices.CreateCompany(company);
            return company;
        }

       
    }
}
