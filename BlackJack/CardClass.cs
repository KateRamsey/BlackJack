using System;

namespace BlackJack
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Clovers
    }

    public enum Rank
    {
        Ace,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Card()
        {
        }

        //test code
        public Card(Rank cardRank)
        {
            Rank = cardRank;
        }
        //end test code


        public Rank Rank {get; set;}
        public Suit Suit {get; set;}

        public int Value()
        {
            switch (this.Rank)
            {
                case Rank.Ace: return 11;
                //case king return 10
                default: return 0;
            }
        }
    }
}
