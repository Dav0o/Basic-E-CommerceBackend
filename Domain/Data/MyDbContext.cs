using Domain.Relations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Cart_Product> Cart_Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cart_Product

            modelBuilder.Entity<Cart_Product>()
                .HasKey(cp => new { cp.ProductId, cp.ShoppingCartId });

            modelBuilder.Entity<Cart_Product>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.Cart_Products)
                .HasForeignKey(cp => cp.ProductId);

            modelBuilder.Entity<Cart_Product>()
                .HasOne(cp => cp.ShoppingCart)
                .WithMany(sc => sc.Cart_Products)
                .HasForeignKey(cp => cp.ShoppingCartId);
        }
    }
}
