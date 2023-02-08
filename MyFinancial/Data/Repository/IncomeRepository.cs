using Microsoft.EntityFrameworkCore;
using MyFinancial.Data.Context;
using MyFinancial.Data.DataModel;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Dto;

namespace MyFinancial.Data.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly AppDbContext _appDbContext;

        public IncomeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteIncome(int id)
        {
            _appDbContext.Income.Remove(await GetIncomeAsync(id));
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            return await _appDbContext.Income.ToListAsync();
        }

        public async Task<Income> GetIncomeAsync(int id)
        {
            return await _appDbContext.Income.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveIncomeAsync(IncomeDto dto)
        {
            await _appDbContext.Income.AddAsync(ConvertToModel(dto));
            await _appDbContext.SaveChangesAsync();
        }

        public void UpdateIncome(IncomeDto dto)
        {
            _appDbContext.Income.Update(ConvertToModel(dto));
            _appDbContext.SaveChanges();
        }

        private static Income ConvertToModel(IncomeDto dto)
        {
            return new Income
            {
                Id = dto.Id,
                Month = dto.Month,
                Amount = dto.Amount,
                UserId = dto.UserId,
            };
        }
    }
}
