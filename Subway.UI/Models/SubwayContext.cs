using Microsoft.EntityFrameworkCore;

namespace Subway.UI.Models
{
    public class SubwayContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SubwayDB;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
