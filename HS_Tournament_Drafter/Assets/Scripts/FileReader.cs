using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class FileReader : MonoBehaviour
{
    [SerializeField]
    private TextAsset[] _classFiles;

    // Start is called before the first frame update
    void Start()
    {
        List<string> data = ReadAllClasses(_classFiles);

        CreateCards(data);
    }

    private List<string> ReadAllClasses(TextAsset[] data)
    {
        List<string> output = new List<string>();

        foreach(TextAsset file in data)
        {
            output.AddRange(file.text.Split("cardId").ToList());
        }

        return output;
    }

    private void CreateCards(List<string> data)
    {
        List<Card> cards = new List<Card>();

        foreach(string element in data)
        {
            string name = "";
            Card.Rarity rarity = Card.Rarity.Common;
            Card.Class cardClass = Card.Class.Neutral;

            if(!element.Contains("\"rarity\":\"Free\""))
            {
                string[] target = element.Split("name\":\"");
                if(target.Length > 1)
                {
                    name = target[1].Split("\",")[0];
                }

                string[] targetRarity = element.Split("rarity\":\"");
                if (targetRarity.Length > 1)
                {
                    rarity = (Card.Rarity)Enum.Parse(typeof(Card.Rarity), targetRarity[1].Split("\",")[0]);
                }

                string[] targetClass = element.Split("playerClass\":\"");
                if (targetClass.Length > 1)
                {
                    string temp = targetClass[1].Split("\",")[0];
                    if (temp == "Demon Hunter")
                        temp = "DemonHunter";

                    cardClass = (Card.Class)Enum.Parse(typeof(Card.Class), temp);
                }
            }

            if (name != "")
            {
                Card newCard = new Card { Name = name, CardRarity = rarity, CardClass = cardClass };
                cards.Add(newCard);
            } 
        }
    }
}
