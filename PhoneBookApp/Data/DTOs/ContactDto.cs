using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Data.DTOs
{
    internal class ContactDto
    {
        public required string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
        public static ContactDto DtoFromContact(Contact contact)
        {
            return new ContactDto { Name = $"{contact.FirstName} {contact.LastName}" };
        }
    }
}
