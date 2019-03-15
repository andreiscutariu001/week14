using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WantsomeThreads.SimpleParallel1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<long>();
            for (long i = 0; i < 100000000; i++)
            {
                list.Add(i);
            }

            var stop = new Stopwatch();
            stop.Start();

            long sum = 0;
            foreach (var l in list)
            {
                sum += l;
            }

            Console.WriteLine($"Elapsed: {stop.ElapsedMilliseconds} ms. Sum: {sum}");

            stop.Restart();
            stop.Start();

            long sum2 = 0;
            Parallel.ForEach(list, l =>
            {
                lock (list)
                {
                    sum2 += l;
                }
            });

            stop.Stop();

            Console.WriteLine($"Elapsed: {stop.ElapsedMilliseconds} ms. Sum: {sum2}");
        }
    }
}