
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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


        public DbSet<Producto> Productos { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        
        public DbSet<ProductCart> ProductsCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


           

            modelBuilder.Entity<ShoppingCart>()
                .HasMany(c => c.ProductCarts)
                .WithOne(pc => pc.ShoppingCart)
                .HasForeignKey(pc => pc.CartId);

            modelBuilder.Entity<ProductCart>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductsCart)
                .HasForeignKey(pc => pc.ProductoId);
        }
    }
}
