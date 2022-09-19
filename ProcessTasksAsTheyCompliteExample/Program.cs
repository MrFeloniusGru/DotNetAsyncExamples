using System;
using System.Threading.Tasks;
using ProcessTasksAsTheyCompliteLib;

internal class Program
{
    private async static Task Main(string[] args)
    {
        async Task<int> WaitAsync(int s)
        {
            await Task.Delay(TimeSpan.FromSeconds(s));
            return s;
        }


        Task<int>[] tasks = new[]
        {
            WaitAsync(3),
            WaitAsync(1),
            WaitAsync(2)
        };

        foreach (var bucket in tasks.Interleaved())
        {
            var task = await bucket;
            Console.WriteLine(await task);
        }
    }
}