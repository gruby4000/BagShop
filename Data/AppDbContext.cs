using BagShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BagShop.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material_Bag>().HasKey(am => new
            {
                am.MaterialId,
                am.BagId
            });

            modelBuilder.Entity<Material_Bag>().HasOne(m => m.Bag).WithMany(am => am.Materials_Bags).HasForeignKey(m => m.BagId);
            modelBuilder.Entity<Material_Bag>().HasOne(m => m.Material).WithMany(am => am.Materials_Bags).HasForeignKey(m => m.MaterialId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Material_Bag> Materials_Bags { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
