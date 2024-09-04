class Program
{
  static void Main(string[] args)
  {
    // Create and start a task using the default task scheduler
    Task task1 = Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Task 1 is running on thread: " +
                        System.Threading.Thread.CurrentThread.ManagedThreadId);
    });

    // Create and start another task using the default task scheduler
    Task task2 = Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Task 2 is running on thread: " +
                        System.Threading.Thread.CurrentThread.ManagedThreadId);
    });

    // Wait for tasks to complete
    Task.WaitAll(task1, task2);

    Console.WriteLine("Both tasks completed.");
  }
}
