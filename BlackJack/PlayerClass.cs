using System;

public class Player
{
	public Player(bool Dealer)
	{
        isDealer = Dealer;
        score = 0;
	}

    public bool isDealer { get; set; }
    public int score { get; set; }

}
