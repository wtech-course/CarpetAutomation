using CarpetAutomation.DataAccess;
using CarpetAutomation.DataAccess.Abstract;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _context;
        private readonly UserManager<Users> _userManager;
        public UserController(IUserService context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //www.geldigitti.com/api/user/create
        [HttpPost("[action]")]
        public async Task<Users> Create([FromBody] Users user)
        {
            await _context.CreateUser(user);   
            
            return user;
        }
        //[HttpPost("[action]")]
        //public async Task RoleAssign(int id)
        //{
        //    Users user = await _userManager.FindByIdAsync(id.ToString());

        //    await _userManager.AddToRoleAsync(user, "Administrator");
        //    await _userManager.AddToRoleAsync(user, "Moderator");
        //    await _userManager.AddToRoleAsync(user, "Editor");
        //    await _userManager.AddToRoleAsync(user, "tor");
          
        //}

    }
}
