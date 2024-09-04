public class Program
{
  public static async Task Main(string[] args)
  {
    try
    {
      var task1 = Task.Run(() => ThrowException("Task 1"));
      var task2 = Task.Run(() => ThrowException("Task 2"));

      await Task.WhenAll(task1, task2);
    }
    catch (AggregateException ex)
    {
      foreach (var innerException in ex.InnerExceptions)
      {
        Console.WriteLine($"Caught exception: {innerException.Message}");
      }
    }
  }

  public static void ThrowException(string taskName)
  {
    throw new InvalidOperationException($"{taskName} encountered an error.");
  }
}