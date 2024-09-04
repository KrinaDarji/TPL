class Program
{
  static void Main()
  {
    // Create a CancellationTokenSource
    CancellationTokenSource cts = new CancellationTokenSource();

    // Start a task and pass the cancellation token
    Task task = Task.Run(() => DoWork(cts.Token), cts.Token);

    // Simulate some work in the main thread
    Thread.Sleep(2000);

    // Request cancellation
    Console.WriteLine("Requesting task cancellation...");
    cts.Cancel();

    try
    {
      // Wait for the task to acknowledge the cancellation
      task.Wait();
    }
    catch (AggregateException ex)
    {
      if (ex.InnerExceptions[0] is TaskCanceledException)
        Console.WriteLine("Task was canceled.");
    }

    Console.WriteLine("Task has completed or was canceled.");
  }

  static void DoWork(CancellationToken token)
  {
    for (int i = 0; i < 10; i++)
    {
      // Check for cancellation
      if (token.IsCancellationRequested)
      {
        Console.WriteLine("Task cancellation detected. Exiting task...");
        token.ThrowIfCancellationRequested();
      }

      Console.WriteLine($"Working on iteration {i}...");
      // Simulate some work with a delay
      Thread.Sleep(1000);
    }

    Console.WriteLine("Task completed successfully.");
  }
}