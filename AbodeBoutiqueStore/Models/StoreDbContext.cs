using Microsoft.EntityFrameworkCore;

namespace AbodeBoutiqueStore.Models
{
    // this class is used to query and save instances of items to the Product database
    // used to seed product data at program launch (if Db is empty)
    // or can be used to facilitate adding new products via user input
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}