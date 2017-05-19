using Microsoft.EntityFrameworkCore;

namespace EFTest
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=company.db");
        }
    }
}
