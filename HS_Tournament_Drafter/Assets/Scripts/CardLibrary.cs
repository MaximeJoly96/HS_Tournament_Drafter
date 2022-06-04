using System.Collections.Generic;
using UnityEngine;

public class CardLibrary
{
    private static CardLibrary _instance;
    public static CardLibrary Instance
    {
        get
        {
            if (_instance == null)
                _instance = new CardLibrary();

            return _instance;
        }
    }

    public List<Card> Cards { get; private set; }

    private CardLibrary() { }

    public void AddCardsToLibrary(List<Card> cards)
    {
        if (Cards == null)
            Cards = new List<Card>();

        Cards.AddRange(cards);
    }

    public void PrintLibrary()
    {
        Debug.Log(Cards.Count);

        foreach (Card card in Cards)
            Debug.Log(card);
    }
}

