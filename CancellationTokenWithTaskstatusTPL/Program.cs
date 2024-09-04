public class Program
{
  public static async Task Main(string[] args)
  {
    var cts = new CancellationTokenSource();

    var task1 = Task.Run(() => HandleException("Task 1", cts.Token));
    var task2 = Task.Run(() => HandleException("Task 2", cts.Token));

    await Task.WhenAll(task1, task2);

    if (task1.Status == TaskStatus.Faulted || task2.Status == TaskStatus.Faulted)
    {
      Console.WriteLine("At least one task encountered an exception.");
      // Handle or report the error
    }
  }

  public static void HandleException(string taskName, CancellationToken token)
  {
    try
    {
      // Simulate an operation
      Thread.Sleep(1000);

      // Check for cancellation request
      token.ThrowIfCancellationRequested();

      // Some operation that might throw an exception
      throw new InvalidOperationException($"{taskName} encountered an error.");
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine($"{taskName} was canceled.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Caught exception in {taskName}: {ex.Message}");
      // Log or report the exception
    }
  }
}