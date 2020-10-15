using System.Diagnostics;
using System.Linq;
using static System.Console;

namespace CompositeProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            var largePocoObjs = Enumerable.Range(0, 50000).Select(s => new LargePocoObj());

            stopwatch.Start();

            foreach (var largePocoObj in largePocoObjs)
            {
                largePocoObj.Status = 1;
            }

            stopwatch.Stop();

            WriteLine($"Regular update: {stopwatch.Elapsed.Milliseconds}");
        }
    }
}
