using Microsoft.EntityFrameworkCore;
using MyFinancial.Data.DataModel;

namespace MyFinancial.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Income> Income { get; set; } = null!;
    }
}
