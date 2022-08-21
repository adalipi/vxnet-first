using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            builder.Entity<SMTH>().HasIndex(i => i.Name).IsUnique();
        }
    }
}
