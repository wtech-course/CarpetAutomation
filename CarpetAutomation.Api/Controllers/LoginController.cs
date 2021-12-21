using CarpetAutomation.Api.Helpers;
using CarpetAutomation.Api.Model;
using CarpetAutomation.DataAccess;
using CarpetAutomation.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpetAutomation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //readonly interface ve classları static yapmamızı sağlar.
        private readonly CarpetDBContext _context;
        private readonly IConfiguration _configration;
        private readonly GenericHelperMethods _genericHelperMethods;
        public LoginController(CarpetDBContext context, IConfiguration configration, GenericHelperMethods genericHelperMethods)
        {
            _context = context;
            _configration = configration;
            _genericHelperMethods = genericHelperMethods;
        }
        //www.geldigitti.com/api/login/create
        [HttpPost("[action]")]
        public async Task<bool> Create([FromBody] Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost("[action]")]
        public async Task<Token> Login([FromBody] UserLogin userlogin)
        {
            Users user = await _context.Users.FirstOrDefaultAsync(w => w.Email == userlogin.Email && w.Password == userlogin.Password);
            if (user != null)
            {
                return await _genericHelperMethods.CreateRefreshToken(user, _context, _configration);
            }
            return null;
        }

        [HttpPost("[action]")]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            Users user = await _context.Users.FirstOrDefaultAsync(w => w.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                return await _genericHelperMethods.CreateRefreshToken(user, _context, _configration);
            }
            return null;
        }


    }
}
