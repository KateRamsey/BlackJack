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
            List<Card> Shoe = new List<Card>();
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    Shoe.Add(new Card(s, r));
                }
            }
            var randomShoe = Shoe.OrderBy(x => Guid.NewGuid()).ToList();

            Player Human = new Player();
            Player Dealer = new Player();

            bool StillPlaying = true;
            char PlayAgain;
            char AnotherCard;
            bool BlackJack = false;

            while (StillPlaying)
            {
                Console.WriteLine("Let's Play!!");
                Console.WriteLine();

                Human.Hand.Add(randomShoe[0]);
                randomShoe.Remove(randomShoe[0]);
                Human.Hand.Add(randomShoe[0]);
                randomShoe.Remove(randomShoe[0]);

                Dealer.Hand.Add(randomShoe[0]);
                randomShoe.Remove(randomShoe[0]);
                Dealer.Hand.Add(randomShoe[0]);
                randomShoe.Remove(randomShoe[0]);

                Console.WriteLine("Your Cards Are:");
                Human.ShowHand();
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
                            Human.Busted = true;
                        }
                        else if (Human.Hand.Count() == 6)
                        {
                            Console.WriteLine("You win by not busting with 6 cards!");
                            Human.TurnEnd = true;
                            Human.SixCardWin = true;
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
                                Human.Hand.Add(randomShoe[0]);
                                randomShoe.Remove(randomShoe[0]);
                                Console.WriteLine("Your hand is now:");
                                Human.ShowHand();
                                Console.WriteLine();
                                Human.SetScore();
                                Console.WriteLine($"You're score is {Human.Score}");
                            }
                            else
                            {
                                Human.TurnEnd = true;
                            }
                        }
                    }

                    if (!Human.Busted && !Human.SixCardWin)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Dealer's hand is:");
                        Dealer.ShowHand();
                        Dealer.SetScore();
                        Console.WriteLine($"Dealer score is {Dealer.Score}");
                        Console.WriteLine();

                        while (Dealer.Score < 16)
                        {
                            Console.WriteLine("The Dealer Hits");
                            Console.WriteLine();
                            Dealer.Hand.Add(randomShoe[0]);
                            randomShoe.Remove(randomShoe[0]);
                            Console.WriteLine("Dealer's Hand is:");
                            Dealer.ShowHand();
                            Console.WriteLine();
                            Dealer.SetScore();
                            Console.WriteLine($"The Dealer's Score is {Dealer.Score}");
                            Console.WriteLine();
                        }

                        Console.WriteLine($"Your score is {Human.Score}, Dealer's score is {Dealer.Score}");
                        if (Human.Score > Dealer.Score)
                        {
                            Console.WriteLine("You Win!");
                        }
                        else if (Human.Score == Dealer.Score)
                        {
                            Console.WriteLine("Ties go to the dealer, you lose");
                        }
                        else if (Dealer.Score > 21)
                        {
                            Console.WriteLine("Dealer Busts and you Win!!");
                        }
                        else
                        {
                            Console.WriteLine("You lose, dealer's score beats yours");
                        }
                    }
                }

                Console.WriteLine();
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
                    randomShoe = Shoe.OrderBy(x => Guid.NewGuid()).ToList();
                    Human.Hand.Clear();
                    Dealer.Hand.Clear();
                    Human.Score = 0;
                    Dealer.Score = 0;
                    BlackJack = false;
                    Human.TurnEnd = false;
                    Dealer.TurnEnd = false;
                    Human.Busted = false;
                    Dealer.Busted = false;
                    Console.Clear();
                }

            }

            Console.ReadLine();
        }
    }
}
