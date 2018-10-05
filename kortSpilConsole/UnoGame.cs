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

        public UnoGame()
        {
            deck = new Deck(this);
            player1 = new Player(this);
            player2 = new Player(this);
        }
       
    }
}
