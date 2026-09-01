using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts => Set<Contact>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = config.GetConnectionString("DefaultConnection")!;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
