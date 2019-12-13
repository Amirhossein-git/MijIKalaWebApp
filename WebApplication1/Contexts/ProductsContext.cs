using Microsoft.EntityFrameworkCore;
using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Contexts
{
    public class ProductsContext : DbContext
    {

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<WarehouseItem> WarehouseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(i => i.ProductId);
            modelBuilder.Entity<Comment>().HasKey(i => i.CommentId);
            modelBuilder.Entity<Warehouse>().HasKey(i => i.WarehouseId);
            modelBuilder.Entity<WarehouseItem>().HasKey(i => i.WraehouseItemId);
            modelBuilder.Entity<Warehouse>().Property(i=>i.WarehouseId).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(i => i.Category).IsRequired();
            modelBuilder.Entity<Product>().Property(i => i.ProductId).IsRequired();
            modelBuilder.Entity<Product>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(i => i.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(i => i.Slogan).HasDefaultValue("-خالی-");
            modelBuilder.Entity<Product>().Property(i => i.ImgSource).HasDefaultValue("-خالی-");
            modelBuilder.Entity<Product>().Property(i => i.HtmlProductDemonstration).HasDefaultValue("-خالی-");
            modelBuilder.Entity<Product>().Property(i => i.DiscountPercentage).HasDefaultValue(0);
        }

    }
}
