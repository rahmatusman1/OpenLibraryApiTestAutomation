using RestSharp;
using System.Diagnostics;

namespace OpenLibraryApiTests.Support;

public class ApiClient
{
    private readonly RestClient _client;
    public RestResponse Response { get; private set; }
    public long ResponseTime { get; private set; }

    public ApiClient()
    {
        _client = new RestClient("https://openlibrary.org");
    }

    public void SendRequest()
    {
        var request = new RestRequest(
            "/api/books?bibkeys=ISBN:0201558025,LCCN:93005405,ISBN:1583762027&format=json",
            Method.Get);

        var stopwatch = Stopwatch.StartNew();
        Response = _client.Execute(request);
        stopwatch.Stop();

        ResponseTime = stopwatch.ElapsedMilliseconds;
    }
}
