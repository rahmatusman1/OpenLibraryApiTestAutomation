using FluentAssertions;
using Newtonsoft.Json.Linq;
using OpenLibraryApiTests.Support;
using Reqnroll;

namespace OpenLibraryApiTests.StepDefinitions;

[Binding]
public class BooksApiSteps
{
    private readonly TestContext _context;
    public BooksApiSteps(TestContext context)
    {
        _context = context;
    }

    [Given(@"I send a GET request to the Open Library endpoint")]
    public void GivenISendAGetRequest()
    {
        _context.ApiClient = new ApiClient();
        _context.ApiClient.SendRequest();
    }


    [Then(@"the response status code should be 200")]
    public void ThenTheResponseSStatusCodeShouldBe200()
    {
        _context.ApiClient.Response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then(@"the response time should be less than {int} milliseconds")]
    public void ThenResponseTimeShouldBeLessThanMilliseconds(int number)
    {
        _context.ApiClient.ResponseTime.Should().BeLessThan(number);
    }
   
    [Then("the book response should contains {int} results")]
    public void ThenTheBookResponseShouldContainsResults(int number)
    {
        var content = _context.ApiClient.Response.Content;
        content.Should().NotBeNull();
        var json = JObject.Parse(content!);
        json.Count.Should().Be(number);
    }


        [Then(@"the returned book details should be correct")]
    public void ThentheReturnedBookDetailsShouldBeCorrect()
    {
        var content = _context.ApiClient.Response.Content;
        content.Should().NotBeNull();
        var json = JObject.Parse(content!);

        var isbnToken = json.GetValue("ISBN:0201558025");
        isbnToken.Should().NotBeNull();
        isbnToken!["info_url"].Should().NotBeNull();

        var lccnToken = json.GetValue("LCCN:93005405");
        lccnToken.Should().NotBeNull();
        lccnToken!["info_url"].Should().NotBeNull();

        var isbn2Token = json.GetValue("ISBN:1583762027");
        isbn2Token.Should().NotBeNull();
        isbn2Token!["info_url"].Should().NotBeNull();
    }

    [Then(@"the thumbnail images should match the stored images")]
    public async Task ThenTheThumbnailImagesShouldMatchTheStoredImages()
    {
        var content = _context.ApiClient.Response.Content;
        content.Should().NotBeNull();
        var json = JObject.Parse(content!);

        foreach (var key in json)
        {
            var thumbnailToken = key.Value?["thumbnail_url"];
            thumbnailToken.Should().NotBeNull();
            var thumbnailUrl = thumbnailToken!.ToString();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var storedPath = Path.Combine( basePath, "StoredImages", $"{key.Key.Replace(":", "_")}.jpg");
            var downloadedPath = Path.Combine(basePath,"StoredImages", $"temp_{key.Key.Replace(":", "_")}.jpg" );
            await ImageHelper.DownloadImageAsync(thumbnailUrl, downloadedPath);

            File.Exists(storedPath).Should().BeTrue("Baseline image must exist");

            var storedHash = ImageHelper.ComputeHash(storedPath);
            var downloadedHash = ImageHelper.ComputeHash(downloadedPath);

            downloadedHash.Should().Be(storedHash);
        }
    }
}
