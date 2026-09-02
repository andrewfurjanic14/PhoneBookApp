using System;
using System.Collections.Generic;
using System.Text;

namespace RandomUserGenerator.Models
{
    internal record class FullNames (
        IReadOnlyList<string> FirstNames,
        IReadOnlyList<string> LastNames
    );
        
    
}
