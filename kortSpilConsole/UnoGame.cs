using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            Player currentPlayer = player1;

            //del 7 kort ud til spillerne
            player1.DrawCard(7);
            player2.DrawCard(7);

            while (gameover != true)
            {
                // vis vores 'revealed' card
                Console.WriteLine(deck.Peek());

                // print player1 med tostring-metoden (navn: g2, b3, r7....)
                Console.WriteLine(currentPlayer);

                // spørg spiller1 om hvilket kort han vil ligge ned
                Console.WriteLine("Vælg et kort fuckhoved!");
                int i = Convert.ToInt32(Console.ReadLine());

                //TODO prøv at 'spille' det valgte kort til bunken
                if (deck.playCard(currentPlayer.Hand[i - 1]))
                {
                    currentPlayer.Hand.Remove(player1.Hand[i - 1]);

                }

                if (currentPlayer.Equals(player1))
                {
                    currentPlayer = player2;
                }
                else currentPlayer = player1;
            }
        }

    }
}
