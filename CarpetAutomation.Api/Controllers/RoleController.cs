using CarpetAutomation.Entities.Model;
using CarpetAutomation.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpetAutomation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IRoleService _roleManager;
        public RoleController(IRoleService roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(AppRole model)
        {
            await _roleManager.CreateRole(model);
            return Ok();
        }
    }
}
