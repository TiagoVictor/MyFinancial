using Microsoft.EntityFrameworkCore;
using MyFinancial.Data.Context;
using MyFinancial.Data.DataModel;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Dto;

namespace MyFinancial.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteUser(int id)
        {
            _appDbContext.Users.Remove(await GetUserAsync(id));
            _appDbContext.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveUserAsync(UserDto dto)
        {
            await _appDbContext.Users.AddAsync(ConvertToModel(dto));
            await _appDbContext.SaveChangesAsync();
        }

        public void UpdateUser(UserDto dto)
        {
            _appDbContext.Users.Update(ConvertToModel(dto));
            _appDbContext.SaveChanges();
        }

        private static User ConvertToModel(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Login = dto.Login,
                PassWord = dto.PassWord,
            };
        }

        public Task<User> GetUserByPassAndLogin(string password, string login)
        {
            return _appDbContext.Users.Where(x => x.PassWord == password && x.Login == login).FirstOrDefaultAsync();
        }

        public Task SaveSalary(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
