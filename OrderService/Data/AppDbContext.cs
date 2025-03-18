using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace OrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
        .Property(o => o.Price)
        .HasColumnType("decimal(18,4)");          
            
        }
    }
}

