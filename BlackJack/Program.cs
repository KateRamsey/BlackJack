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

            //TEST SECTION
            int score = 0;
            Card TestCard = new Card(Rank.Eight);
            score = TestCard.Value();
            Console.WriteLine(score);

            //END TEST SECTION

            //create deck
            Player Human = new Player();
            Player Dealer = new Player();
            Human.isDealer = false;
            Dealer.isDealer = true;


            //Game Loop

            //shuffle deck

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

            //ask "Play again?"


            Console.ReadLine();
        }
    }
}
