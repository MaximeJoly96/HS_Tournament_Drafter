using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviour
{
    private List<string> _players;

    [SerializeField]
    private Button _addButton;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _players = new List<string>();
    }

    private void AddPlayer(string player)
    {
        _players.Add(player);
    }
}
