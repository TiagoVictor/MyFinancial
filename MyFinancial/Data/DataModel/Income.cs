namespace MyFinancial.Data.DataModel
{
    public class Income
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Active { get; set; }
    }
}
