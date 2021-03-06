﻿using System;
using System.Collections;
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
        private bool playerLoop = true;
        private int antalSpillere;

        public UnoGame()
        {
            deck = new Deck(this);

            while (playerLoop)
            {
                Console.WriteLine("Hvor mange spillere er i? (2-8 personer)");
                Console.Write(">");
                antalSpillere = Convert.ToInt32(Console.ReadLine());
                if (antalSpillere >= 9 || antalSpillere < 2)
                {
                    Console.WriteLine("Ugyldigt input");
                }
                else
                {
                    playerLoop = false;
                }

            }
            
            
            for (int i = 1; i <= antalSpillere; i++)
            {
                Console.WriteLine("Skriv navn på spiller " + i);
                string name = Console.ReadLine();
                players.Add(new Player(name, this));
            }
            
//            players.Add(new Player("Alfa", this));
//            players.Add(new Player("Beta", this));
//            players.Add(new Player("Charlie", this));
//            players.Add(new Player("Delta", this));

            currentPlayer = players.First();
            //del kort ud til spiller 1
            players[0].DrawCard(7);
//            players[0].DebugDrawCard("red", "+2");
//            players[0].DebugDrawCard("blue", "+2");
//            players[0].DebugDrawCard("yellow", "+2");
//            players[0].DebugDrawCard("green", "+2");
//
//            players[1].DebugDrawCard("red", "+2");
//            players[1].DebugDrawCard("blue", "+2");
//            players[1].DebugDrawCard("yellow", "+2");
//            players[1].DebugDrawCard("green", "+2");
            //del 7 kort ud til resten af spillerne
            for (int i = 1; i < players.Count; i++)
            {
                players[i].DrawCard(7);
            }

            while (!gameover)
            {
                // vis vores 'revealed' card
                Console.WriteLine(deck.Peek());

                // print player1 med tostring-metoden (navn: g2, b3, r7....)
                Console.WriteLine(currentPlayer);

                // spørg spiller1 om hvilket kort han vil ligge ned
                Console.WriteLine("Spil et uno kort!"); 
                Console.Write(">");
                int i = Convert.ToInt32(Console.ReadLine());

                //TODO prøv at 'spille' det valgte kort til bunken
                if (deck.playCard(currentPlayer.Hand[i - 1]))
                {
                    if (currentPlayer.Hand[i-1].Value == "+2")
                    {
                        if (currentPlayer == players.Last())
                        {
                            Console.WriteLine("Næste spiller " + players.First().name + " trækker 2 kort");
                            players.First().DrawCard(2);
                        }
                        else
                        {
                            Console.WriteLine("Næste spiller " + players[players.IndexOf(currentPlayer) + 1].name + " trækker 2 kort");
                            players[players.IndexOf(currentPlayer) + 1].DrawCard(2);
                        }
                        currentPlayer.Hand.Remove(currentPlayer.Hand[i - 1]);
                    }
                    else if (currentPlayer.Hand[i - 1].Value == "change +4")
                    {
                        if (currentPlayer == players.Last())
                        {
                            Console.WriteLine("Næste spiller " + players.First().name + " trækker 4 kort");
                            players.First().DrawCard(4);
                        }
                        else
                        {
                            Console.WriteLine("Næste spiller " + players[players.IndexOf(currentPlayer) + 1].name + " trækker 4 kort");
                            players[players.IndexOf(currentPlayer) + 1].DrawCard(4);
                        }

                        Console.WriteLine("Hvilken farve vil du have? (b)lue, (g)reen, (y)ellow eller (r)ed");
                        Console.Write(">");
                        string newColor = Console.ReadLine();
                        if (newColor == "b")currentPlayer.Hand[i - 1].Color = "blue";
                        else if (newColor == "g")currentPlayer.Hand[i - 1].Color = "green";
                        else if (newColor == "y")currentPlayer.Hand[i - 1].Color = "yellow";
                        else if (newColor == "r")currentPlayer.Hand[i - 1].Color = "red";

                        currentPlayer.Hand.Remove(currentPlayer.Hand[i - 1]);
                    }
                    else if (currentPlayer.Hand[i - 1].Value == "change")
                    {
                        Console.WriteLine("Hvilken farve vil du have? (b)lue, (g)reen, (y)ellow eller (r)ed");
                        Console.Write(">");
                        string newColor = Console.ReadLine();
                        if (newColor == "b") currentPlayer.Hand[i - 1].Color = "blue";
                        else if (newColor == "g") currentPlayer.Hand[i - 1].Color = "green";
                        else if (newColor == "y") currentPlayer.Hand[i - 1].Color = "yellow";
                        else if (newColor == "r") currentPlayer.Hand[i - 1].Color = "red";

                        currentPlayer.Hand.Remove(currentPlayer.Hand[i - 1]);
                    }
                    //TODO Skip kort fjerner et kort fra den man skipper, samt skip kortet, som lægges ikke fjernes.
                    else if (currentPlayer.Hand[i - 1].Value == "skip")
                    {
                        currentPlayer.Hand.Remove(currentPlayer.Hand[i - 1]);
                        nextPlayer();
                    }
                    else if (currentPlayer.Hand[i - 1].Value == "reverse")
                    {
                        players.Reverse();
                        currentPlayer.Hand.Remove(currentPlayer.Hand[i - 1]);
                    }
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
