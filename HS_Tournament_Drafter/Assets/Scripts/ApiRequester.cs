using System;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Events;

public class ApiRequester
{
    private StringsListEvent _apiRequestHasFinished;
    public StringsListEvent ApiRequestHasFinished
    {
        get
        {
            if (_apiRequestHasFinished == null)
                _apiRequestHasFinished = new StringsListEvent();

            return _apiRequestHasFinished;
        }
    }

    public void RetrieveApiData()
    {
        string[] classes = new string[]
        {
            "Neutral",
            "Mage",
            "Paladin",
            "Rogue",
            "Warlock",
            "Hunter",
            "Demon Hunter",
            "Shaman",
            "Priest",
            "Warrior",
            "Druid"
        };

        List<string> result = new List<string>();

        foreach (string c in classes)
            result.Add(GetDataForClass(c));

        ApiRequestHasFinished.Invoke(result);
    }

    private string GetDataForClass(string className)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/classes/" + className + "?collectible=1"),
            Headers =
            {
                { "X-RapidAPI-Host", "omgvamp-hearthstone-v1.p.rapidapi.com" },
                { "X-RapidAPI-Key", "52f7b10a6dmshfb3fda9417ec2e1p1dd1cdjsn0740a7db824f" },
            },
        };

        using (var response = client.SendAsync(request))
        {
            var body = response.Result.Content.ReadAsStringAsync();
            return body.Result;
        }
    }
}