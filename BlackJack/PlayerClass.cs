using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Player()
        {
            Score = 0;
            TurnEnd = false;
            Busted = false;
            SixCardWin = false;
        }

        public int Score { get; set; }
        public int AceScore { get; set; }
        public bool TurnEnd { get; set; }
        public bool Busted { get; set; }
        public bool SixCardWin { get; set; }

        public void ShowHand()
        {
            foreach(Card c in Hand)
            {
                c.Show();
            }
        }

        public void SetScore()
        {
            Score = 0;
            foreach(Card c in Hand)
            {
                Score += c.Value();
            }
        }

        public void SetAceScore()
        {
            AceScore = 0;
            foreach(Card c in Hand)
            {
                if(c.Value() == 11)
                {
                    AceScore += 1;
                }
                else
                {
                    AceScore += c.Value();
                }
            }
        }


        public List<Card> Hand = new List<Card>();

    }
}
