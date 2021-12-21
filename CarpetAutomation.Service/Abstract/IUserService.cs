using CarpetAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Abstract
{
    public interface IUserService 
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task<Users> CreateUser(Users newUser);
        Task UpdateUser(Users userToBeUpdated, Users user);
        Task DeleteUser(Users user);
    }
}
