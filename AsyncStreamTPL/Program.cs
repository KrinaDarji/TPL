class Program
{
  static async Task Main(string[] args)
  {
    // Create an instance of the asynchronous data source
    var dataSource = new AsynchronousDataSource();

    // Use await foreach to asynchronously iterate over the data stream
    await foreach (var data in dataSource.GetDataAsync())
    {
      Console.WriteLine($"Received data: {data}");
    }

    Console.WriteLine("Data processing complete.");
  }
}

public class AsynchronousDataSource
{
  public async IAsyncEnumerable<int> GetDataAsync()
  {
    // Simulate fetching data asynchronously
    for (int i = 1; i <= 5; i++)
    {
      await Task.Delay(1000); // Simulate a delay
      yield return i; // Yield the next data item
    }
  }
}
