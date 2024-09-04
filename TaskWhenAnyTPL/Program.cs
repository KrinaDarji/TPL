class Program
{
  static async Task Main(string[] args)
  {
    using (var cts = new CancellationTokenSource())
    {
      var tasks = new Task<string>[]
      {
                FetchDataFromApiAsync("https://api1.example.com/data", cts.Token),
                FetchDataFromApiAsync("https://api2.example.com/data", cts.Token),
                FetchDataFromApiAsync("https://api3.example.com/data", cts.Token)
      };

      Task<string> firstTask = await Task.WhenAny(tasks);

      // Cancel the other tasks
      cts.Cancel();

      // Process the result from the fastest task
      Console.WriteLine("Data from fastest API: " + await firstTask);
    }
  }

  static async Task<string> FetchDataFromApiAsync(string url, CancellationToken cancellationToken)
  {
    using (var httpClient = new HttpClient())
    {
      try
      {
        // Simulate a delay for demo purposes
        await Task.Delay(new Random().Next(1000, 5000), cancellationToken);

        HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
      }
      catch (OperationCanceledException)
      {
        return "Task was cancelled.";
      }
      catch (Exception ex)
      {
        return $"Error fetching data from {url}: {ex.Message}";
      }
    }
  }
}
