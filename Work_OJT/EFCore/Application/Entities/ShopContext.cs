using Microsoft.EntityFrameworkCore;

namespace EFCore.Application.Entities
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> products { get; set;}
        public DbSet<Category> categories { get; set;}
    }
}
