using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
