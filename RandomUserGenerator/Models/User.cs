using System;
using System.Collections.Generic;
using System.Text;

namespace RandomUserGenerator.Models
{
    public record class User (
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber
    );
}
