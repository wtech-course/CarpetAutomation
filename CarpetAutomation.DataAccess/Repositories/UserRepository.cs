using CarpetAutomation.Entities.Model;
using CarpetAutomation.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarpetAutomation.DataAccess.Repositories
{
    public class UserRepository :Repository<Users>,IUserRepository
    {
        public UserRepository(CarpetDBContext context) : base(context)
        { }
        private CarpetDBContext CarpetDBContext
        {
            get { return Context as CarpetDBContext; }
        }
    }
}
