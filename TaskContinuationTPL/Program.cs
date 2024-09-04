class Program
{
  static void Main()
  {
    // Create and start the first task
    Task firstTask = Task.Run(() =>
    {
      Console.WriteLine("First task is running...");
      // Simulate some work with a delay
      Task.Delay(1000).Wait();
      Console.WriteLine("First task completed.");
    });

    // Continue with the second task after the first one completes
    Task continuationTask = firstTask.ContinueWith((t) =>
    {
      Console.WriteLine("Continuation task is running...");
      // Simulate some work with a delay
      Task.Delay(1000).Wait();
      Console.WriteLine("Continuation task completed.");
    });

    // Wait for the continuation task to complete
    continuationTask.Wait();

    Console.WriteLine("All tasks have completed.");
  }