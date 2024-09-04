class SequentialTaskScheduler : TaskScheduler
{
  private readonly Queue<Task> _tasks = new Queue<Task>();
  private bool _isRunning = false;

  protected override IEnumerable<Task> GetScheduledTasks()
  {
    return _tasks;
  }

  protected override void QueueTask(Task task)
  {
    lock (_tasks)
    {
      _tasks.Enqueue(task);
      if (!_isRunning)
      {
        _isRunning = true;
        ProcessNextTask();
      }
    }
  }

  private void ProcessNextTask()
  {
    if (_tasks.Count > 0)
    {
      Task task = _tasks.Dequeue();
      base.TryExecuteTask(task);
      ProcessNextTask();
    }
    else
    {
      _isRunning = false;
    }
  }

  protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
  {
    return false; // No inline execution allowed
  }
}

class Program
{
  static void Main(string[] args)
  {
    var scheduler = new SequentialTaskScheduler();

    // Create tasks using the custom scheduler
    Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Task 1 is running sequentially.");
    }, CancellationToken.None, TaskCreationOptions.None, scheduler);

    Task.Factory.StartNew(() =>
    {
      Console.WriteLine("Task 2 is running sequentially.");
    }, CancellationToken.None, TaskCreationOptions.None, scheduler);

    Console.ReadLine(); // Wait to see the output
  }
}
