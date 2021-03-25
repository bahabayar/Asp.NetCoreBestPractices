using Asp.NetCoreBestPractices.Core.Models;
using Asp.NetCoreBestPractices.Data.Configurations;
using Asp.NetCoreBestPractices.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCoreBestPractices.Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//veritabanında tablolar oluşmadan önce çalışan metot
        {
            //modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn(); burayada kodlayabilirdik bu şekidle
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1,2}));
            
        }
    }
}
