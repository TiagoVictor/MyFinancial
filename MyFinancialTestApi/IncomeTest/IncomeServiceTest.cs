using MyFinancial.Data.DataModel;
using MyFinancial.Dto;
using MyFinancial.Service.Interface;

namespace MyFinancialTestApi.IncomeTest
{
    public class IncomeServiceTeste : IIncomeService
    {
        private readonly List<Income> _incomes;
        private readonly List<IncomeDto> _incomesDto;


        public IncomeServiceTeste()
        {
            _incomes = new List<Income>()
            {
                new Income() {Id = 1, Active = true, Amount = 4500.00, CreatedAt = DateTime.Now, Month = DateTime.Now, UserId = 1 },
                new Income() {Id = 2, Active = false, Amount = 5500.00, CreatedAt = DateTime.Now, Month = DateTime.Now, UserId = 1 },
            };

            _incomesDto = new List<IncomeDto>()
            {
                new IncomeDto() {Id = 1, Active = true, Amount = 3000.00, CreatedAt = DateTime.Now, Month = DateTime.Now, UserId = 2 },
                new IncomeDto() {Id = 2, Active = false, Amount = 4000.00, CreatedAt = DateTime.Now, Month = DateTime.Now, UserId = 1 },
                new IncomeDto() {Id = 3, Active = true, Amount = 5000.00, CreatedAt = DateTime.Now, Month = DateTime.Now, UserId = 3 },
            };
        }

        public async Task DeleteIncome(int id)
        {
            var item = _incomes.First(x => x.Id == id);
            _incomes.Remove(item);
        }

        public async Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            return _incomes;
        }

        public async Task<Income> GetIncomeAsync(int id)
        {
            return _incomes
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task SaveIncomeAsync(IncomeDto dto)
        {
            dto.Id = GeraId();
            _incomesDto.Add(dto);
        }

        public void UpdateIncome(IncomeDto dto)
        {
            throw new NotImplementedException();
        }

        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
