using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        private static Semaphore semaphore;
        static void Main(string[] args)
        {
            semaphore = new Semaphore(10, 10);
            int minThreads, minIO;
            ThreadPool.GetMinThreads(out minThreads, out minIO);
            ThreadPool.SetMinThreads(10, minIO);
            ThreadPool.QueueUserWorkItem(DoWork, 100);
            Console.WriteLine("Main thread exit");
            Console.ReadKey();
        }

        public static void DoWork(object state)
        {
            semaphore.WaitOne();
            var counter = (int)state;
            counter--;
            Console.WriteLine($"Tread id: {Thread.CurrentThread.ManagedThreadId}, counter: {counter}");
            if (counter != 0)
            {
                ThreadPool.QueueUserWorkItem(DoWork, counter);
                Thread.Sleep(100);
            }
            semaphore.Release();
        }

    }
}
