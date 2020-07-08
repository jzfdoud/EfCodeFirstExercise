using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCodeFirstExercise.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

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
        // protectrd means program class cannot call this, only if another class inherits this class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent API statements go here
        }
    }
}
