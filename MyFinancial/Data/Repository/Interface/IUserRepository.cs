using MyFinancial.Data.DataModel;
using MyFinancial.Dto;

namespace MyFinancial.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task SaveUserAsync(UserDto dto);
        void UpdateUser(UserDto dto);
        Task DeleteUser(int id);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByPassAndLogin(string password, string login);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
