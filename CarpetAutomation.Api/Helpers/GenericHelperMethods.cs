using CarpetAutomation.DataAccess;
using CarpetAutomation.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarpetAutomation.Api.Helpers
{
    public class GenericHelperMethods
    {
        public GenericHelperMethods()
        {

        }
        public async Task<Token> CreateRefreshToken(Users user, CarpetDBContext _context, IConfiguration _configuration)
        {
            //User için token üretiliyor.
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken();
            //fresh token kullanıcı tablosuna işleniyor.
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
            await _context.SaveChangesAsync();
            return token;
        }

       
    }
}
