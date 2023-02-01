using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MyFinancial.Data.DataModel;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Dto;
using MyFinancial.Service.Interface;

namespace MyFinancial.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<User> GetUserByPassAndLogin(string password, string login)
        {
            return await _userRepository.GetUserByPassAndLogin(password, login);
        }

        public async Task SaveUserAsync(UserDto dto)
        {
            await _userRepository.SaveUserAsync(dto);
        }

        public void UpdateUser(UserDto dto)
        {
            _userRepository.UpdateUser(dto);
        }
    }
}
