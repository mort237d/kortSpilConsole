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
        List<Player> players = new List<Player>();
        private Player currentPlayer;
        private bool gameover = false;

        public UnoGame()
        {
            deck = new Deck(this);
            
            players.Add(new Player("Alfa", this));
            players.Add(new Player("Beta", this));
            currentPlayer = players.First();
            //del kort ud til spiller 1
            players[0].DrawCard(3);
            players[0].DebugDrawCard("red", "+2");
            players[0].DebugDrawCard("green", "+2");
            players[0].DebugDrawCard("blue", "+2");
            players[0].DebugDrawCard("yellow", "+2");
            //del 7 kort ud til resten af spillerne
            for (int i = 1; i < players.Count; i++)
            {
                players[i].DrawCard(7);
            }

            while (gameover != true)
            {
                // vis vores 'revealed' card
                Console.WriteLine(deck.Peek());

                // print player1 med tostring-metoden (navn: g2, b3, r7....)
                Console.WriteLine(currentPlayer);

                // spørg spiller1 om hvilket kort han vil ligge ned
                Console.WriteLine("Spil et uno kort!");
                int i = Convert.ToInt32(Console.ReadLine());

                //TODO prøv at 'spille' det valgte kort til bunken
                if (deck.playCard(currentPlayer.Hand[i - 1]))
                {
                    if (currentPlayer.Hand[i-1].Value == "+2")
                    {
                        Console.WriteLine("Næste spiller trækker 2 kort");
                        players[players.IndexOf(currentPlayer) + 1].DrawCard();
                        players[players.IndexOf(currentPlayer) + 1].DrawCard();
                    }
                    currentPlayer.Hand.Remove(currentPlayer.Hand[i - 1]);
                    
                }
                else
                {
                    currentPlayer.DrawCard();
                }

                nextPlayer();
            }
        }

        private void nextPlayer()
        {
            if (currentPlayer == players.Last())
            {
                currentPlayer = players.First();
            }
            else
            {
                int currentPlayerPosition = players.IndexOf(currentPlayer);
                currentPlayer = players[currentPlayerPosition + 1];
            }
        }
    }
}
