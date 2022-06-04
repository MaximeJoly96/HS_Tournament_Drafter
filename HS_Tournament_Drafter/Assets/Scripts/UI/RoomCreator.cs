using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviour
{
    private List<Player> _players;

    [SerializeField]
    private Button _addButton;
    [SerializeField]
    private InputField _inputField;
    [SerializeField]
    private Text _playersList;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _players = new List<Player>();
        _addButton.onClick.AddListener(AddCurrentPlayer);
    }

    public void AddPlayer(string player)
    {
        _players.Add(new Player(player));
        _playersList.text += "\n" + player;
    }

    public void AddCurrentPlayer()
    {
        string content = _inputField.text;

        if(content != "")
            AddPlayer(content);
    }
}
