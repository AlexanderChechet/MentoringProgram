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
        private static List<string> sharedCollection = new List<string>();
        private static readonly ManualResetEventSlim addEventSlim = new ManualResetEventSlim(false);
        private static readonly ManualResetEventSlim printEventSlim = new ManualResetEventSlim(true);
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            TaskFlow();
            //ThreadFlow();
            Console.WriteLine("Main thread ends");
            Console.ReadKey();
        }

        #region Thread implementation
        private static void ThreadFlow()
        {
            var firstThread = new Thread(DoFirstThreadWork);
            var secondThread = new Thread(DoSecondThreadWork);
            secondThread.Start();
            firstThread.Start();
        }

        private static void DoFirstThreadWork()
        {
            for (int i = 0; i < 10; i++)
            {
                AddItem(sharedCollection, i.ToString());
                addEventSlim.Set();
                //TODO: Think on implementation without sleep;
                //Thread.Sleep(100);
            }
            printEventSlim.Reset();
            Console.WriteLine("First thread end");
        }

        private static void DoSecondThreadWork()
        {
            while (printEventSlim.IsSet)
            {
                if (addEventSlim.Wait(1000))
                {
                    addEventSlim.Reset();
                    PrintCollection(sharedCollection);
                }
            }
            Console.WriteLine("Second thread end");
        }

        #endregion


        #region Task implementation
        private static void TaskFlow()
        {
            for (int i = 0; i < 10; i++)
            {
                var addAndPrintTask = Task.Factory.StartNew(DoFirstTaskWork, i)
                    .ContinueWith(DoSecondTaskWork);
                Task.WaitAll(addAndPrintTask);
            }
        }

        private static void DoFirstTaskWork(object state)
        {
            var item = state.ToString();
            AddItem(sharedCollection, item);
        }

        private static void DoSecondTaskWork(Task task)
        {
            PrintCollection(sharedCollection);
        }

        #endregion


        #region Collection actions
        private static void AddItem(List<string> collection, string item)
        {
            lock (lockObject)
            {
                collection.Add(item);
            }
        }

        private static void PrintCollection(List<string> collection)
        {
            lock (lockObject)
            {
                foreach (var item in collection)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        #endregion

    }
}
