using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class UserChoice<T>
    {
        public required string Label { get; set; }
        public required T Value { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
