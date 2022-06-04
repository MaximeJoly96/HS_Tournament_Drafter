using System.Collections.Generic;

public class PlayersSingleton
{
    private static PlayersSingleton _instance;
    public static PlayersSingleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PlayersSingleton();

            return _instance;
        }
    }

    public List<Player> ActivePlayers { get; private set; }

    private PlayersSingleton() 
    {
        ActivePlayers = new List<Player>();
    }

    public void AddPlayers(IEnumerable<Player> players)
    {
        ActivePlayers.AddRange(players);
    }
}
