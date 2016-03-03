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

        public Rank Rank {get; set;}
        public Suit Suit {get; set;}

        public int Value()
        {
            switch (this.rank)
            {
                // case Ace return 11
                //case king return 10
                //etc
            }
        }
    }
}
