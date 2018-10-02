using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Program
    {
        //Oliver was gud
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine(deck);

            Card c = deck.Draw();
            Console.WriteLine(c);
            Console.WriteLine("");
            Console.WriteLine(deck);

            Console.ReadLine();
        }
    }
}
