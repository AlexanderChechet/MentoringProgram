using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        public static List<string> sharedCollection = new List<string>();
        public static ManualResetEventSlim addEventSlim = new ManualResetEventSlim(false);
        public static ManualResetEventSlim printEventSlim = new ManualResetEventSlim(true);
        public static object lockObject = new object();

        static void Main(string[] args)
        {
            var firstThread = new Thread(DoFirstWork);
            var secondThread = new Thread(DoSecondWork);
            secondThread.Start();
            firstThread.Start();
            Console.WriteLine("Main thread ends");
            Console.ReadKey();
        }

        public static void DoFirstWork()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (lockObject)
                {
                    sharedCollection.Add(i.ToString());
                    addEventSlim.Set();
                }
                //TODO: Think on implementation without sleep;
                Thread.Sleep(100);
            }
            printEventSlim.Reset();
            Console.WriteLine("First thread end");
        }

        public static void DoSecondWork()
        {
            while (printEventSlim.IsSet)
            {
                if (addEventSlim.Wait(1000))
                {
                    lock (lockObject)
                    {
                        PrintCollection(sharedCollection);
                        Console.WriteLine("Add Event Reset");
                        addEventSlim.Reset();
                    }
                }
            }
            Console.WriteLine("Second thread end");
        }

        private static void PrintCollection(IEnumerable<object> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item.ToString() + " ");
            }
        }
    }
}
