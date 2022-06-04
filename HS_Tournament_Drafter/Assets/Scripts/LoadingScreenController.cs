using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    private void Start()
    {
        ApiRequester apiRequester = new ApiRequester();
        FileReader fileReader = new FileReader();

        apiRequester.ApiRequestHasFinished.AddListener(fileReader.ReceiveApiData);
        fileReader.CardsCreatedEvent.AddListener(CardLibrary.Instance.AddCardsToLibrary);

        apiRequester.RetrieveApiData();

        StartCoroutine(LoadRoomCreationScene());
    }

    private IEnumerator LoadRoomCreationScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("RoomCreation");
    }
}
