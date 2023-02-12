using MyFinancial.Data.DataModel;
using MyFinancial.Dto;
using MyFinancial.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinancialTestApi.UserTest
{
    public class UserServiceTest : IUserService
    {
        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByPassAndLogin(string password, string login)
        {
            throw new NotImplementedException();
        }

        public Task SaveUserAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
