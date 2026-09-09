using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

        public static Contact NameOnlySentinel(string name)
        {
            return new Contact 
            {
                FirstName = name,
                LastName = "",
                Email = "",
                PhoneNumber = ""
            };
        }
    }
}
