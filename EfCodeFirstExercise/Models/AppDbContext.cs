using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCodeFirstExercise.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // allows us to configure the DbContext?
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = @"server=localhost\sqlexpress;database=SalesDb28;trusted_connection=true;";
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(connStr);
            }

        } 
        // protected means program class cannot call this, only if another class inherits this class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.Property("Code").HasMaxLength(8).IsRequired(true);
                e.HasIndex("Code").IsUnique();
            });
            //required means cant be null, doesnt mean has to be unique
            //fluent API statements go here
        }
    }
}
