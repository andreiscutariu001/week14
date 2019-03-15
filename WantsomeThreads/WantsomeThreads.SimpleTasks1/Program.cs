using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace WantsomeThreads.SimpleTasks1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"[Main Start] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            //var thread1 = new Thread(Function1);
            //thread1.Start();

            var task1 = new Task<int>(Function1);
            task1.Start();
            //task1.Wait();

            var task2 = new Task<int>(Function2);
            task2.Start();
            //task2.Wait();

            var task3 = new Task<int>(Function3);
            task3.Start();
            //task3.Wait();

            Task.WaitAll(task1, task2, task3);

            var result = task1.Result + task2.Result + task3.Result;

            Console.WriteLine($"[Main End] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();
        }

        public static int Function1()
        {
            Console.WriteLine($"[Start - Child Task - Function1] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            Console.WriteLine($"[End - Child Task - Function1] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            return 100;
        }

        public static int Function2()
        {
            Console.WriteLine($"[Start - Child Task - Function2] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            Console.WriteLine($"[End - Child Task - Function2] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            return 200;
        }

        public static int Function3()
        {
            Console.WriteLine($"[Start - Child Task - Function3] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            Console.WriteLine($"[End - Child Task - Function3] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            return 300;
        }
    }
}