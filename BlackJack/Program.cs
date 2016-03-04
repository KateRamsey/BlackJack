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

            //Game Loop
            while (StillPlaying)
            {
                Console.WriteLine("Let's Play!!");
                //deal 2 cards to player
                //deal 2 cards to dealer

                //show player cards
                //show dealer card #1

                //calculate and display player score
                //if player score == 21, player wins, skip to end

                //while player's turn
                //if player score > 21 they lose, skip to end
                //else ask to hit or stay, if stay dealers turn, else deal
                //calculate and display player score


                //Dealer's turn
                //show hidden card
                //calculate and display score
                //check win
                //check lose
                //while dealer's score < 16
                //hit
                //calculate and display score
                //check win
                //check lose


                //Calculate and display winner

                Console.WriteLine("Would you like to play again? Please press 'Y' or 'N'");
                PlayAgain = char.Parse(Console.ReadLine());
                while(PlayAgain != 'Y' && PlayAgain != 'y' && PlayAgain != 'n' && PlayAgain != 'N')
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
                }
            }

            Console.ReadLine();
        }
    }
}
