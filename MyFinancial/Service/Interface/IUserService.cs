using MyFinancial.Data.DataModel;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Dto;

namespace MyFinancial.Service.Interface
{
    public interface IUserService
    {
        Task SaveUserAsync(UserDto dto);
        Task DeleteUserAsync(int id);
        void UpdateUser(UserDto dto);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByPassAndLogin(string password, string login);
    }
}
