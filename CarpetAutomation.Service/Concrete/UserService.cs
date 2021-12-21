using CarpetAutomation.Entities.Model;
using CarpetAutomation.Entities.Repositories;
using CarpetAutomation.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarpetAutomation.Service.Concrete
{
    public class UserService :IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Users> CreateUser(Users user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return user;
        }

        public async Task DeleteUser(Users user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        

        public Task<Users> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(Users userToBeUpdated, Users user)
        {
            userToBeUpdated.UserName = user.UserName;
            await _unitOfWork.CommitAsync();
        }
  
       
    }
}
