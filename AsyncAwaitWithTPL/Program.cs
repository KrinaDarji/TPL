public class Program
{
  // The Main method should be async Task, not static void
  public static async Task Main(string[] args)
  {
    Console.WriteLine($"Main thread started. Thread ID: {Environment.CurrentManagedThreadId}");

    // Asynchronously run a CPU-bound operation on a background thread using Task.Run
    int computationResult = await Task.Run(() => PerformHeavyComputation());

    Console.WriteLine($"Computation completed. Result: {computationResult}");
    Console.WriteLine($"Main thread finished. Thread ID: {Environment.CurrentManagedThreadId}");
  }

  private static int PerformHeavyComputation()
  {
    Console.WriteLine($"Performing heavy computation on thread ID: {Environment.CurrentManagedThreadId}");

    // Simulate a CPU-bound operation
    double sum = 0;
    for (int i = 1; i <= 1000000; i++)
    {
      sum += Math.Sqrt(i);
    }

    return (int)sum; // Return a computed result as an integer
  }
}
