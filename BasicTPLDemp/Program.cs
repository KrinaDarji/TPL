class Program
{
  static void Main()
  {
    // Creating and starting tasks
    Task task1 = Task.Run(() => PerformTask(1));
    Task task2 = Task.Run(() => PerformTask(2));

    // Waiting for all tasks to complete
    Task.WaitAll(task1, task2);

    Console.WriteLine("All tasks have completed.");
  }

  static void PerformTask(int taskId)
  {
    Console.WriteLine($"Task {taskId} is starting...");
    // Simulate some work with a delay
    Task.Delay(1000).Wait();
    Console.WriteLine($"Task {taskId} has completed.");
  }
}