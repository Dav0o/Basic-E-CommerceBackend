
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
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //Cart -> Details

            modelBuilder.Entity<ShoppingCart>()
            .HasMany(e => e.Details)
            .WithOne(e => e.ShoppingCart)
            .HasForeignKey(e => e.CartId)
            .IsRequired(true);

            //product ->details

            modelBuilder.Entity<Producto>()
            .HasMany(e => e.Details)
            .WithOne(e => e.Producto)
            .HasForeignKey(e => e.ProductoId)
            .IsRequired(true);
        }
    }
}
