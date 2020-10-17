using System;
using System.Diagnostics;
using System.Linq;
using static System.Console;

namespace CompositeProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengthOfCollection = 10000;

            PocoCollection(lengthOfCollection);
            CompositeProxy(lengthOfCollection);
        }

        private static void PocoCollection(int lengthOfCollection)
        {
            var stopwatch = new Stopwatch();
            var random = new Random();

            stopwatch.Start();

            var largePocoObjs = Enumerable.Range(0, lengthOfCollection).Select(s => new LargePocoObj()
            {
                StringOne = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray()),
                LongOne = ulong.MinValue,
                StringTwo = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray()),
                LongTwo = long.MinValue,
                StringThree = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray()),
                Status = 0,
                StringFour = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray())
            }).ToList();

            stopwatch.Stop();

            WriteLine($"Regular Setup Done: {stopwatch.Elapsed.Milliseconds}");

            stopwatch.Reset();
            stopwatch.Start();

            foreach (var largePocoObj in largePocoObjs)
            {
                largePocoObj.Status = 1;
            }

            stopwatch.Stop();

            WriteLine($"Regular Update Done: {stopwatch.Elapsed.Milliseconds}"); // 1: 551, 2: 
        }

        private static void CompositeProxy(int lengthOfCollection)
        {
            var stopwatch = new Stopwatch();
            var random = new Random();

            stopwatch.Start();

            var largePocoObjs = new LargePocoObjs(lengthOfCollection);

            foreach (var largePocoObj in largePocoObjs)
            {
                largePocoObj.StringOne = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
                largePocoObj.LongOne = ulong.MinValue;
                largePocoObj.StringTwo = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
                largePocoObj.LongTwo = long.MinValue;
                largePocoObj.StringThree = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
                largePocoObj.Status = 0;
                largePocoObj.StringFour = new string(Enumerable.Repeat(Constants.Chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
            }

            stopwatch.Stop();

            WriteLine($"Composite Setup Done: {stopwatch.Elapsed.Milliseconds}");

            stopwatch.Reset();

            stopwatch.Start();

            foreach (var largePocoObj in largePocoObjs)
            {
                largePocoObj.Status = 1;
            }

            stopwatch.Stop();

            WriteLine($"Composite Update Done: {stopwatch.Elapsed.Milliseconds}");
        }
    }
}
