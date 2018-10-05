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

            //TODO del 7 kort ud til spillerne

            //TODO vis vores 'revealed' card

            //TODO print player1 med tostring-metoden (navn: g2, b3, r7....)
            //TODO spørg spiller1 om hvilket kort han vil ligge ned
            //TODO prøv at 'spille' det valgte kort til bunken

            //TODO print player2 med tostring metoden (navn: g2, b3, r7....)
            //TODO spørg spiller2 om hvilket kort han vil ligge ned
            //TODO prøv at 'spille' det valgte kort til bunken

        }

    }
}
