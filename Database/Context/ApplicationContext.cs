using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //setting of db Relations, PK, FK
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API
            #region Tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion

            #region PK
            //assigning the primaries keys to the entities
            modelBuilder.Entity<Product>().HasKey(product => product.Id); //Lambda
            modelBuilder.Entity<Category>().HasKey(category => category.Id); //Lambda
            #endregion

            #region FK

            //set relationship with FK
            modelBuilder.Entity<Category>().HasMany<Product>(category => category.Products) // 1:N Relationship
                .WithOne(product => product.Category) // N:1 Relationship
                .HasForeignKey(product => product.CategoryId) // FK
                .OnDelete(DeleteBehavior.Cascade); // if any category is deleted with data product, the products will be deleted
            #endregion

            #region Properties Configuration

            #region Product

            //table products
            //property Name VARCHAR(150)
            modelBuilder.Entity<Product>().Property(product => product.Name).HasMaxLength(150);
            #endregion

            #region Category
            modelBuilder.Entity<Category>().Property(product => product.Name).HasMaxLength(150);
            #endregion

            #endregion

        }
    }
}
