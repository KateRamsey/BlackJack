using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Player(bool Dealer)
        {
            isDealer = Dealer;
            Score = 0;
        }

        public bool isDealer { get; set; }
        public int Score { get; set; }

        public void SetScore()
        {
            foreach(Card c in Hand)
            {
                Score += c.Value();
            }
        }


        public List<Card> Hand = new List<Card>();

    }
}
