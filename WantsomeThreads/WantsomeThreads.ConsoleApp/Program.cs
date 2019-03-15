using System;
using System.Threading;

namespace WantsomeThreads.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                Console.WriteLine($"Hello from created thread with id - {Thread.CurrentThread.ManagedThreadId}");
            });
            thread.Start();

            Console.WriteLine($"Hello from main thread with id - {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();
        }
    }
}