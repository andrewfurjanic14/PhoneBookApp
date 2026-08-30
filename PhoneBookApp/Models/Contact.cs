using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Models
{
    internal class Contact
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
