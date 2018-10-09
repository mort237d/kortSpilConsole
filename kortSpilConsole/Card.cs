using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Card
    {
        public String Color { get; set; }
        public String Value { get; set; }
 
        public Card(String color, String value)
        {
            Color = color;
            Value = value;
        }

        public override string ToString()
        {
            return Value + ", " + Color;
        }
    }
}
