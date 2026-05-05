using Microsoft.EntityFrameworkCore;

namespace FarouqsRecordShop.Models
{
    public class RecordShopContext : DbContext
    {
        public RecordShopContext(DbContextOptions<RecordShopContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
    }
}
