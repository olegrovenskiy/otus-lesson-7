using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace WebApi.Models
{
    class CustomerContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public CustomerContext()
        {
            Database.EnsureCreated();
        }
        //       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //       {
        //           optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hwlesson7;Username=postgres;Password=12345");
        //       }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }





    }
}
