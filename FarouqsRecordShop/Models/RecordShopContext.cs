using Microsoft.EntityFrameworkCore;
namespace FarouqsRecordShop.Models
{
    public class RecordShopContext : DbContext
    {
        public RecordShopContext(DbContextOptions<RecordShopContext> options) : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=FAROUQ2025\\SQLEXPRESS;Database=RecordShopDb;User Id=sa;Password=Firstsource2014;TrustServerCertificate=True;");
            }
        }
    }
}
