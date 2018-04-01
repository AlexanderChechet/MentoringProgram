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
        private static readonly List<string> sharedCollection = new List<string>();
        private static readonly ManualResetEventSlim addEventSlim = new ManualResetEventSlim(false);
        private static readonly ManualResetEventSlim printEventSlim = new ManualResetEventSlim(true);
        private static volatile bool isPrintThreadRequired = true;
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Task flow");
            TaskFlow();
            ResetCollection(sharedCollection);
            Console.WriteLine("Thread flow");
            ThreadFlow();
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
                if (printEventSlim.Wait(1000))
                {
                    try
                    {
                        printEventSlim.Reset();
                        AddItem(sharedCollection, i.ToString());
                    }
                    finally
                    {
                        addEventSlim.Set();
                    }
                }
            }
            isPrintThreadRequired = false;
            Console.WriteLine("First thread end");
        }

        private static void DoSecondThreadWork()
        {
            while (isPrintThreadRequired)
            {
                if (addEventSlim.Wait(1000))
                {
                    try
                    {
                        addEventSlim.Reset();
                        PrintCollection(sharedCollection);
                    }
                    finally
                    {
                        printEventSlim.Set();
                    }
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

        private static void ResetCollection(List<string> collection)
        {
            lock (lockObject)
            {
                Console.WriteLine("Collection reset");
                collection.Clear();
            }
        }

        #endregion

    }
}
