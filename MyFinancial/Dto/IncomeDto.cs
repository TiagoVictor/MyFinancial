using MyFinancial.Data.DataModel;

namespace MyFinancial.Dto
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }

    public class IndexIncomeDto
    {
        public IEnumerable<Income> List { get; set; }
    }
}
