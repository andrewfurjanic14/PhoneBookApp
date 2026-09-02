using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Services
{
    internal class ContactService
    {
        private readonly AppDbContext _db;
        public ContactService(AppDbContext db)
        {
            _db = db;
        }

        /*public async Task<List<Contact>> GetAllAsync()
        {

        }*/

    }
}
