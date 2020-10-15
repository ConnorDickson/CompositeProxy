using System;
using System.Linq;

namespace CompositeProxy
{
    public class LargePocoObj
    {
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string StringOne { get; set; } = new string(Enumerable.Repeat(chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
        public string StringTwo { get; set; } = new string(Enumerable.Repeat(chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
        public string StringThree { get; set; } = new string(Enumerable.Repeat(chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
        public string StringFour { get; set; } = new string(Enumerable.Repeat(chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
        public string StringFive { get; set; } = new string(Enumerable.Repeat(chars, 50000).Select(s => s[random.Next(s.Length)]).ToArray());
        public ulong LongOne { get; set; } = ulong.MinValue;
        public long LongTwo { get; set; } = long.MinValue;
        public int Status { get; set; } = 0;
    }
}