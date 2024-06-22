using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;

namespace RestaurantManagement.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.MenuItem)
                .WithMany()
                .HasForeignKey(c => c.MenuItemId);
        }
    }
}
