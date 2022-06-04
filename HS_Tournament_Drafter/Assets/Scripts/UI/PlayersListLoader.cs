using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PlayersListLoader : MonoBehaviour
{
    [SerializeField]
    private Text _textArea;
    [SerializeField]
    private GameObject _card;
    [SerializeField]
    private Transform _cardsArea;

    private void Start()
    {
        LoadPlayers(PlayersSingleton.Instance.ActivePlayers);
    }

    private void LoadPlayers(List<Player> players)
    {
        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < players.Count; i++)
        {
            if (i > 0)
                sb.Append("\n");

            sb.Append((i + 1) + ". " + players[i].Name);

            GameObject card = Instantiate(_card);
            card.transform.SetParent(_cardsArea);
        }

        _textArea.text = sb.ToString();
    }
}
