public class Program
{
  public static async Task Main(string[] args)
  {
    var urls = new List<string>
        {
            "https://example.com/page1",
            "https://example.com/page2",
            "https://example.com/page3"
        };

    // Initiate the download tasks
    var downloadTasks = urls.Select(DownloadContentAsync).ToArray();

    // Await all tasks to complete
    var downloadResults = await Task.WhenAll(downloadTasks);

    Console.WriteLine("All downloads are done:");
    foreach (var content in downloadResults)
    {
      Console.WriteLine(content);
    }
  }

  private static async Task<string> DownloadContentAsync(string url)
  {
    using var client = new HttpClient();
    return await client.GetStringAsync(url);
  }
}
