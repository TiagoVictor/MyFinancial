using MyFinancial.Data.DataModel;
using MyFinancial.Dto;

namespace MyFinancial.Service.Interface
{
    public interface IIncomeService
    {
        Task SaveIncomeAsync(IncomeDto dto);
        void UpdateIncome(IncomeDto dto);
        Task DeleteIncome(int id);
        Task<Income> GetIncomeAsync(int id);
        Task<IEnumerable<Income>> GetAllIncomesAsync();
    }
}
