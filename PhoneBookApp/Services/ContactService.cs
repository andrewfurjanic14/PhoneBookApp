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
        public async Task AddAsync(Contact contact)
        {
            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();
        }
        public async Task AddAsync(List<Contact> contacts)
        {
            foreach (Contact c in contacts)
            {
            _db.Contacts.Add(c);
            }
            await _db.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAllAsync()
            => await _db.Contacts.ToListAsync();
        
        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _db.Contacts
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _db.Contacts.Update(contact);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact contact)
        {
            _db.Contacts.Remove(contact);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _db.Contacts
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
