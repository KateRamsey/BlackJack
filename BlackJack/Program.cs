using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> Deck = new List<Card>();
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    Deck.Add(new Card(s, r));
                }
            }
            var randomDeck = Deck.OrderBy(x => Guid.NewGuid()).ToList();

            Player Human = new Player(false);
            Player Dealer = new Player(true);

            bool StillPlaying = true;
            char PlayAgain;
            char AnotherCard;
            bool BlackJack = false;

            //Game Loop
            while (StillPlaying)
            {
                Console.WriteLine("Let's Play!!");

                Human.Hand.Add(randomDeck[0]);
                randomDeck.Remove(randomDeck[0]);
                Human.Hand.Add(randomDeck[0]);
                randomDeck.Remove(randomDeck[0]);

                Dealer.Hand.Add(randomDeck[0]);
                randomDeck.Remove(randomDeck[0]);
                Dealer.Hand.Add(randomDeck[0]);
                randomDeck.Remove(randomDeck[0]);

                Console.WriteLine("Your Cards Are:");
                Human.Hand[0].Show();
                Human.Hand[1].Show();
                Console.WriteLine();

                Console.WriteLine("Dealer's First Card Is:");
                Dealer.Hand[0].Show();
                Console.WriteLine();

                Human.SetScore();
                Console.WriteLine($"You're score is {Human.Score}");
                if (Human.Score == 21)
                {
                    Console.WriteLine("BlackJack, you win!!");
                    Console.WriteLine();
                    BlackJack = true;
                }

                if (!BlackJack)
                {
                    while (!Human.TurnEnd)
                    {
                        if (Human.Score > 21)
                        {
                            Console.WriteLine($"Bummer, you bust with a score of {Human.Score}!");
                            Human.TurnEnd = true;
                        }
                        else
                        {
                            Console.WriteLine("Would you like another card? (H)it or (S)tay");
                            AnotherCard = char.Parse(Console.ReadLine());
                            while (AnotherCard != 'H' && AnotherCard != 'h' && AnotherCard != 'S' && AnotherCard != 's')
                            {
                                Console.WriteLine("Please press 'H' for hit or 'S' for stay");
                                AnotherCard = char.Parse(Console.ReadLine());
                            }
                            if (AnotherCard == 'H' || AnotherCard == 'h')
                            {
                                Human.Hand.Add(randomDeck[0]);
                                randomDeck.Remove(randomDeck[0]);
                                //display hand
                                Human.SetScore();
                                Console.WriteLine($"You're score is {Human.Score}");
                            }
                            else
                            {
                                Human.TurnEnd = true;
                            }
                        }
                    }


                    //Dealer's turn//////////////

                    Console.WriteLine("Dealer's Second Card Is:");
                    Dealer.Hand[1].Show();
                    Dealer.Score = Dealer.Hand[0].Value() + Dealer.Hand[1].Value();
                    Console.WriteLine($"Dealer score is {Dealer.Score}");

                    while (Dealer.Score < 16)
                    {
                        Dealer.Hand.Add(randomDeck[0]);
                        randomDeck.Remove(randomDeck[0]);
                        //Show hand <---- Make method??
                        // Dealer.Score = //step through Dealer.Hand;

                        Dealer.Score = 21; //This is here to prevent infinate loop in testing, delete this line!!

                    }

                    //Calculate and display winner
                }
                    
                Console.WriteLine("Would you like to play again? Please press 'Y' or 'N'");
                PlayAgain = char.Parse(Console.ReadLine());
                while (PlayAgain != 'Y' && PlayAgain != 'y' && PlayAgain != 'n' && PlayAgain != 'N')
                {
                    Console.WriteLine("Please press 'Y' or 'N'");
                    PlayAgain = char.Parse(Console.ReadLine());
                }

                if (PlayAgain == 'N' || PlayAgain == 'n')
                {
                    StillPlaying = false;
                    Console.WriteLine("Thanks for playing, have a great day!");
                }
                else
                {
                    randomDeck = Deck.OrderBy(x => Guid.NewGuid()).ToList();
                    Human.Hand.Clear();
                    Dealer.Hand.Clear();
                    Human.Score = 0;
                    Dealer.Score = 0;
                    BlackJack = false;
                    Human.TurnEnd = false;
                    Dealer.TurnEnd = false;
                    Console.Clear();
                }
                
            }

            Console.ReadLine();
        }
    }
}
