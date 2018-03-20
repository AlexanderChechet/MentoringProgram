using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("End");
            Console.ReadKey();
        }

        private static void CaseA()
        {
            Console.WriteLine("Case A");
            var cancellationTokenSource = new CancellationTokenSource();
            var caseATask = Task.Run((Action)SimpleWriteline, cancellationTokenSource.Token)
                .ContinueWith(task => Continuation());
            cancellationTokenSource.Cancel();
            try
            {
                caseATask.Wait(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message + " " + e);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
            Console.WriteLine("End case A");
        }

        private static void CaseB()
        {
            Console.WriteLine("Case B");
            var caseBTask = Task.Run((Action)SimpleWriteline)
                .ContinueWith(task => Continuation(), TaskContinuationOptions.NotOnRanToCompletion);
            try
            {
                caseBTask.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e);
            }
            Console.WriteLine("End case B");
        }

        private static void CaseC()
        {
            //TO DO Execute in correct thread
            Console.WriteLine("Case B");
            var caseBTask = Task.Run((Action)SimpleWriteline)
                .ContinueWith(task =>TaskContinuationOptions.OnlyOnFaulted);
            try
            {
                caseBTask.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e);
            }
            Console.WriteLine("End case B");
        }

        private static void SimpleWriteline()
        {
            Console.WriteLine("Parent task start");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            throw new NullReferenceException();
            Console.WriteLine("Parent task end");
        }

        private static void Continuation()
        {
            Console.WriteLine("Continuation task start");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Continuation task end");
        }
    }
}
