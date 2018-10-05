using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Player
    {
        private UnoGame game;

        public Player(UnoGame game)
        {
            this.game = game;
        }

        public List<Card> Hand { get; set; }

        public void DrawCard()
        {
            Hand.Add(game.deck.Draw());
        }

        public void DrawCard(int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                DrawCard();
            }
        }

        public override string ToString()
        {
            //TODO print player navn og hans/hendes 'hånd'
            return base.ToString();
        }
    }
}
