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

                Human.Score += Human.Hand[0].Value() + Human.Hand[1].Value();
                Console.WriteLine($"You're score is {Human.Score}");
                if (Human.Score == 21)
                {
                    Console.WriteLine("BlackJack, you win!!");
                    Console.WriteLine();
                    BlackJack = true;
                }

                if (!BlackJack)
                {
                    //while player's turn
                    //if player score > 21 they lose, skip to end
                    //else ask to hit or stay, if stay dealers turn, else deal
                    //calculate and display player score


                    //Dealer's turn//////////////
 
                    Console.WriteLine("Dealer's Second Card Is:");
                    Dealer.Hand[1].Show();
                    //calculate and display score
                    Dealer.Score = Dealer.Hand[0].Value() + Dealer.Hand[1].Value();
                    Console.WriteLine($"Dealer score is {Dealer.Score}");
                    //check win
                    //check lose
                    //while dealer's score < 16
                    //hit
                    //calculate and display score
                    //check win
                    //check lose


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
                    Console.Clear();
                }
                
            }

            Console.ReadLine();
        }
    }
}
