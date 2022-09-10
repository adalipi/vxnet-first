using vxnet.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace vxnet.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            builder.Entity<UserManager>().HasIndex(i => i.Username).IsUnique();
            builder.Entity<AppInstance>();
            builder.Entity<Shop>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<Product>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<Category>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<ProductPerShop>().HasKey(p => new { p.ProductId, p.ShopId });
        }
    }
}
