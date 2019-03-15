using System;
using System.Threading;
using System.Threading.Tasks;

namespace WantsomeThreads.AsyncAwait
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(new RunAsyncCode2().Run().GetAwaiter().GetResult());
        }
    }

    public class RunAsyncCode
    {
        public int Run()
        {
            var sum = 0;

            var task1 = new Task<int>(MethodA);
            task1.Start();
            task1.Wait();

            sum += task1.Result;

            var task2 = new Task<int>(MethodB);
            task2.Start();
            task2.Wait();

            sum += task2.Result;

            return sum;
        }

        private int MethodA()
        {
            Console.WriteLine($"[MethodA] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");
            return 100;
        }

        private int MethodB()
        {
            Console.WriteLine($"[MethodB] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");
            return 200;
        }
    }

    public class RunAsyncCode2
    {
        public async Task<int> Run()
        {
            var sum = 0;

            sum += await MethodA();
            sum += await MethodB();

            return sum;
        }

        private async Task<int> MethodA()
        {
            Console.WriteLine($"[MethodA] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");
            return 100;
        }

        private async Task<int> MethodB()
        {
            Console.WriteLine($"[MethodB] Hello from thread with id: {Thread.CurrentThread.ManagedThreadId}");

            return 200;
        }
    }
}