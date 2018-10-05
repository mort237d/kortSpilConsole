using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class UnoGame
    {
        public Deck deck;
        public Player player1;
        public Player player2;

        private bool gameover = false;

        public UnoGame()
        {
            deck = new Deck(this);
            player1 = new Player("Alfa", this);
            player2 = new Player("Beta", this);

            //del 7 kort ud til spillerne
            player1.DrawCard(7);
            player2.DrawCard(7);

            while (gameover != true)
            {
                // vis vores 'revealed' card
                Console.WriteLine(deck.Peek());

                // print player1 med tostring-metoden (navn: g2, b3, r7....)
                Console.WriteLine(player1);

                // spørg spiller1 om hvilket kort han vil ligge ned
                Console.WriteLine("Vælg et kort fuckhoved!");
                int i = Convert.ToInt32(Console.ReadLine());

                //TODO prøv at 'spille' det valgte kort til bunken
                if (deck.playCard(player1.Hand[i - 1]))
                {
                    player1.Hand.Remove(player1.Hand[i - 1]);

                }

                Console.WriteLine(deck.Peek());

                //TODO print player2 med tostring metoden (navn: g2, b3, r7....)
                Console.WriteLine(player2);

                //TODO spørg spiller2 om hvilket kort han vil ligge ned
                Console.WriteLine("Vælg et kort fuckhoved!");
                int j = Convert.ToInt32(Console.ReadLine());

                //TODO prøv at 'spille' det valgte kort til bunken
                if (deck.playCard(player2.Hand[j - 1]))
                {
                    player2.Hand.Remove(player2.Hand[j - 1]);
                }

                Console.WriteLine(deck.Peek());
            }
        }

    }
}
