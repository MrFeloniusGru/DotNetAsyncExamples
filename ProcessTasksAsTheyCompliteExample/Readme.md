This project is console application based on the **_Stephen Toub_** [Processing tasks as they complete](https://devblogs.microsoft.com/pfxteam/processing-tasks-as-they-complete/) article and shows the method of processing task's results in order they have been completed.

The simple approach to process tasks in order they have been completed is using waitAny() in the loop. But this method has computational complexity O(n^2)
```c#
var tasks = new List<Task>{
    new Task.Delay(TimeSpan.FromSecond(3)),
    new Task.Delay(TimeSpan.FromSecond(2)),
    new Task.Delay(TimeSpan.FromSecond(1))
}

while(tasks.Any())
{
    var task = await Task.WhenAny(tasks);
    Console.WriteLine($"task {task.Id} is complited");
    tasks.Remove(task);
}
```

The method described in the article and implemented in this project has computational complexity O(n)
