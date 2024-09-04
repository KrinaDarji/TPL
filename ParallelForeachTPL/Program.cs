class Program
{
  static void Main()
  {
    var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // Using Parallel.ForEach to process a collection in parallel
    Parallel.ForEach(items, item =>
    {
      Console.WriteLine($"Processing item {item} on thread {Task.CurrentId}");
      // Simulate some work with a delay
      Task.Delay(500).Wait();
    });

    Console.WriteLine("All items processed.");
  }
}