
namespace OpenLibraryApiTests.Support;

public static class ImageHelper
{
    public static async Task DownloadImageAsync(string url, string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }
        using var client = new HttpClient();
        var imageBytes = await client.GetByteArrayAsync(url);
        await File.WriteAllBytesAsync(filePath, imageBytes);
    }

    public static string ComputeHash(string filePath)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        using var stream = File.OpenRead(filePath);
        var hash = sha256.ComputeHash(stream);
        return Convert.ToHexString(hash);
    }
}
