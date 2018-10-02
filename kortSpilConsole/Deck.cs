using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Deck
    {
        Card[] cards = new Card[76];

        public Deck()
        {
            for (int i = 0; i < 10; i++)
            {
                // red cards
                cards[i] = new Card("red", i);
                cards[i+9] = new Card("red", i);

                //blue cards
                cards[i+19] = new Card("blue", i);
                cards[i + 28] = new Card("blue", i);

                //green cards
                cards[i + 38] = new Card("green", i);
                cards[i + 47] = new Card("green", i);

                //yellow cards
                cards[i + 57] = new Card("yellow", i);
                cards[i + 66] = new Card("yellow", i);
            }

            for (int i = 0; i < cards.Length; i++)
            {
                Console.WriteLine(cards[i]);
            }
        }

    }
}
