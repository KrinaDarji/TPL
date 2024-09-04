public class TaskFactoryDemo
{
  public static void Main(string[] args)
  {
    // Initiating a task using Task.Factory
    Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Execution of the first task has begun.");
    }, TaskCreationOptions.None);

    // Initiating a task designed for long-running operations
    Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Execution of a long-running task has started.");
      // Simulate a CPU-intensive operation
      for (int i = 0; i < 1000000; i++)
      {
        double result = Math.Sqrt(i);
      }
    }, TaskCreationOptions.LongRunning);

    // Creating a parent task with an attached child task
    Task parentTask = Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Parent task is running.");
      // Create and attach a child task to the parent
      Task.Factory.StartNew(() =>
      {
        Console.WriteLine("Child task is running.");
      }, TaskCreationOptions.AttachedToParent);
    });

    // Ensuring the parent task completes before proceeding
    parentTask.Wait();

    Console.WriteLine("Execution of all tasks has concluded.");
  }
}
