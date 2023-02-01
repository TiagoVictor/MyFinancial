namespace MyFinancial.Data.DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string PassWord { get; set; }
        public string Login { get; set; }
    }
}
