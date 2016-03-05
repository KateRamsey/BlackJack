﻿using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Player(bool Dealer)
        {
            isDealer = Dealer;
            Score = 0;
            TurnEnd = false;
        }

        public bool isDealer { get; set; }
        public int Score { get; set; }
        public bool TurnEnd { get; set; }

        public void SetScore()
        {
            Score = 0;
            foreach(Card c in Hand)
            {
                Score += c.Value();
            }
        }


        public List<Card> Hand = new List<Card>();

    }
}
