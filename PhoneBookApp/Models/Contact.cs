using RandomUserGenerator.Models;
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

        public override string ToString()
        {
            return $"""
                {FirstName} {LastName}
                Email: {Email}
                Phone Number: {PhoneNumber}
                """;
        }

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

        public static Contact FromUser(User user)
        {
            return new Contact
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
