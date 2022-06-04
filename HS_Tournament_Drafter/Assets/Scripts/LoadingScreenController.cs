using UnityEngine;

public class LoadingScreenController : MonoBehaviour
{
    private void Start()
    {
        ApiRequester apiRequester = new ApiRequester();
        FileReader fileReader = new FileReader();

        apiRequester.ApiRequestHasFinished.AddListener(fileReader.ReceiveApiData);
        fileReader.CardsCreatedEvent.AddListener(CardLibrary.Instance.AddCardsToLibrary);

        apiRequester.RetrieveApiData();
        CardLibrary.Instance.PrintLibrary();
    }
}
