using System.Collections.Generic;

public class Player
{
    public string Name { get; private set; }
    public List<Card> AvailableCards { get; private set; }

    public Player(string name)
    {
        Name = name;
        AvailableCards = new List<Card>();
    }

    public void GiveCard(Card card)
    {
        AvailableCards.Add(card);
    }
}

