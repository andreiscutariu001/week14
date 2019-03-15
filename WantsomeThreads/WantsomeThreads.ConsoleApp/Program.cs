using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace WantsomeThreads.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"[Main Thread] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            var thread1 = new Thread(Function1);
            thread1.Start();

            var thread2 = new Thread(Function2);
            thread2.Start();

            var thread3 = new Thread(Function3);
            thread3.Start();

            //Function1();

            //Function2();

            //Function3();

            Console.ReadKey();
        }

        public static void Function1()
        {
            Console.WriteLine($"[Start - Child Thread - Function1] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            var list = new List<long>();
            for (long j = 0; j < 10000000; j++)
            {
                var s = j.ToString();
                var l = long.Parse(s);
                list.Add(l);
            }

            Console.WriteLine($"[End - Child Thread - Function1] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void Function2()
        {
            Console.WriteLine($"[Start - Child Thread - Function2] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            var list = new List<long>();
            for (long j = 0; j < 10000000; j++)
            {
                var s = j.ToString();
                var l = long.Parse(s);
                list.Add(l);
            }

            Console.WriteLine($"[End - Child Thread - Function2] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void Function3()
        {
            Console.WriteLine($"[Start - Child Thread - Function3] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            var list = new List<long>();
            for (long j = 0; j < 10000000; j++)
            {
                var s = j.ToString();
                var l = long.Parse(s);
                list.Add(l);
            }

            Console.WriteLine($"[End - Child Thread - Function3] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}