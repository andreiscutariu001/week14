using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WantsomeThreads.SimpleThread1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            const decimal numberOfElements = 10000000m;

            var list = GenerateListFromZeroTo(numberOfElements);
            var sum = CalculateSum(list);

            stopwatch.Stop();

            Console.WriteLine($"calculate sum {sum} ({numberOfElements} elements) in {stopwatch.ElapsedMilliseconds} ms");
        }

        private static decimal CalculateSum(IReadOnlyCollection<decimal> list)
        {
            decimal sum = 0;

            for (var i = 0; i < list.Count; i++)
            {
                // simulate a long operation
                var temp = i.ToString();
                sum += long.Parse(temp);
            }

            return sum;
        }

        private static List<decimal> GenerateListFromZeroTo(decimal numberOfElements)
        {
            var list = new List<decimal>();

            for (var i = 0; i < numberOfElements; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}