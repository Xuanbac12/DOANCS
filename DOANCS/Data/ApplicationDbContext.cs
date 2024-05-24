using DOANCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DOANCS.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Color> Colors{ get; set; }

        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Product>()
           .HasOne(pa => pa.Category)
           .WithMany(p => p.Products)
           .HasForeignKey(pa => pa.CategoryId);

            modelbuilder.Entity<ProductDetail>()
           .HasOne(pa => pa.Product)
           .WithMany(p => p.ProductDetails)
           .HasForeignKey(pa => pa.ProductId);

            modelbuilder.Entity<ProductDetail>()
           .HasOne(pa => pa.Color)
           .WithMany(p => p.ProductDetails)
           .HasForeignKey(pa => pa.ColorId);

            modelbuilder.Entity<ProductDetail>()
           .HasOne(pa => pa.Size)
           .WithMany(p => p.ProductDetails)
           .HasForeignKey(pa => pa.SizeId);


        }
    }

}
