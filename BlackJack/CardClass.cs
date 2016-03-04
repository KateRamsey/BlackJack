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

        public void Show()
        {
            switch (Rank)
            {
                case Rank.Ace:
                    Console.Write("Ace of "); break;
                case Rank.King:
                    Console.Write("King of "); break;
                case Rank.Queen:
                    Console.Write("Queen of "); break;
                case Rank.Jack:
                    Console.Write("Jack of "); break;
                case Rank.Ten:
                    Console.Write("Ten of "); break;
                case Rank.Nine:
                    Console.Write("Nine of "); break;
                case Rank.Eight:
                    Console.Write("Eight of "); break;
                case Rank.Seven:
                    Console.Write("Seven of "); break;
                case Rank.Six:
                    Console.Write("Six of "); break;
                case Rank.Five:
                    Console.Write("Five of "); break;
                case Rank.Four:
                    Console.Write("Four of "); break;
                case Rank.Three:
                    Console.Write("Three of "); break;
                case Rank.Deuce:
                    Console.Write("Deuce of "); break;
            }

            switch (Suit)
            {
                case Suit.Clubs:
                    Console.WriteLine("Clubs"); break;
                case Suit.Diamonds:
                    Console.WriteLine("Diamonds"); break;
                case Suit.Hearts:
                    Console.WriteLine("Hearts"); break;
                case Suit.Spades:
                    Console.WriteLine("Spades"); break;
            }
            return;
        }
    }
}
