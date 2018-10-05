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
            
        }
    }
}
