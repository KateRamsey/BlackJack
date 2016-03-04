using System;

namespace BlackJack
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
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
        public Card(Suit s, Rank r)
        {
            this.Rank = r;
            this.Suit = s;
        }


        public Rank Rank {get; set;}
        public Suit Suit {get; set;}

        public int Value()
        {
            switch (Rank)
            {
                case Rank.Ace: return 11;
                case Rank.King:
                case Rank.Queen:
                case Rank.Jack:
                case Rank.Ten: return 10;
                case Rank.Nine: return 9;
                case Rank.Eight: return 8;
                case Rank.Seven: return 7;
                case Rank.Six: return 6;
                case Rank.Five: return 5;
                case Rank.Four: return 4;
                case Rank.Three: return 3;
                case Rank.Deuce: return 2;
                default: return 0;
            }
        }
    }
}
