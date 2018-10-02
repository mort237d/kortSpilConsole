using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Deck
    {
        List<Card> cards = new List<Card>();
        //Card[] cards = new Card[76];

        public Deck()
        {
            for (int i = 0; i < 10; i++)
            {
                // red cards
                cards.Add(new Card("red", i));
                cards.Add(new Card("red", i));

                //blue cards
                cards.Add(new Card("blue", i));
                cards.Add(new Card("blue", i));

                //green cards
                cards.Add(new Card("green", i));
                cards.Add(new Card("green", i));

                //yellow cards
                cards.Add(new Card("yellow", i));
                cards.Add(new Card("yellow", i));

            }

            shuffle();
        }

        public Card Draw()
        {
            Card c = cards[0]; //finder øverste kort
            cards.Remove(c); //fjerner kort fra bunken (c = øverste kort)
            return c; //giver kortet til den der kalder metoden
        }

        public void shuffle()
        {
            // shuffle array
            Random random = new Random();
            cards = cards.OrderBy(x => random.Next()).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cards.Count; i++)
            {
                sb.Append(cards[i]);
                sb.Append("; ");
            }

            return sb.ToString();
        }
    }
}
