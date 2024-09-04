class Program
{
  static void Main()
  {
    // Using Parallel.For to execute a loop in parallel
    Parallel.For(0, 10, i =>
    {
      Console.WriteLine($"Processing item {i} on thread {Task.CurrentId}");
      // Simulate some work with a delay
      Task.Delay(500).Wait();
    });

    Console.WriteLine("All items processed.");
  }
}