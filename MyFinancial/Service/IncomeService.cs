using MyFinancial.Data.DataModel;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Dto;
using MyFinancial.Service.Interface;
using SQLitePCL;

namespace MyFinancial.Service
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task DeleteIncome(int id)
        {
            await _incomeRepository.DeleteIncome(id);
        }

        public Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            return _incomeRepository.GetAllIncomesAsync();
        }

        public Task<Income> GetIncomeAsync(int id)
        {
            return _incomeRepository.GetIncomeAsync(id);
        }

        public async Task SaveIncomeAsync(IncomeDto dto)
        {
            await _incomeRepository.SaveIncomeAsync(dto);
        }

        public void UpdateIncome(IncomeDto dto)
        {
            _incomeRepository.UpdateIncome(dto);
        }
    }
}
