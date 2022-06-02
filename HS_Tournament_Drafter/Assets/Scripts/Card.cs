public class Card
{
    public enum Rarity { Common, Rare, Epic, Legendary }
    public enum Class { Neutral, Mage, Paladin, Rogue, Hunter, DemonHunter, Shaman, Warrior, Warlock, Druid, Priest }

    public Rarity CardRarity { get; set; }
    public Class CardClass { get; set; }

    public string Name { get; set; }

    public override string ToString()
    {
        return Name + " " + CardRarity + " " + CardClass;
    }
}
