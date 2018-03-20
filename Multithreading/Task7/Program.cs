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
            var cancellationTokenSource = new CancellationTokenSource();
            Console.WriteLine("Enter option");
            var option = Console.ReadLine();
            try
            {
                var task = CreateTask(option, cancellationTokenSource.Token);
                Console.WriteLine("Create and start Task");
                //Console.WriteLine("Cancel task");
                //cancellationTokenSource.Cancel();
                task.Wait(cancellationTokenSource.Token);
                Console.WriteLine("End Task");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (AggregateException list)
            {
                foreach (var ex in list.InnerExceptions)
                {
                    if (ex is TaskCanceledException)
                        Console.WriteLine(ex.Message);
                    else
                        Console.WriteLine(ex.Message + " " + ex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
            
            Console.ReadKey();
        }

        private static Task CreateTask(string option, CancellationToken token)
        {
            Task result = null;
            switch (option)
            {
                case "A":
                    Console.WriteLine("Regardless execution");
                    result = CaseA(token);
                    break;
                case "B":
                    Console.WriteLine("Without success execution");
                    result = CaseB(token);
                    break;
                case "C":
                    Console.WriteLine("Fail and same thread execution");
                    result = CaseC(token);
                    break;
                case "D":
                    Console.WriteLine("Out of thread on cancel execution");
                    result = CaseD(token);
                    break;
                default:
                    throw new ArgumentException("Wrong case");
            }   
            return result;
        }

        private static Task CaseA(CancellationToken token)
        {
            var task = Task.Run((Action)SimpleWriteline, token)
                .ContinueWith(x => Continuation());
            return task;   
        }

        private static Task CaseB(CancellationToken token)
        {
            var task = Task.Run((Action)SimpleWriteline)
                .ContinueWith(x => Continuation(), TaskContinuationOptions.NotOnRanToCompletion);
            return task;
        }

        private static Task CaseC(CancellationToken token)
        {
            var task = Task.Factory.StartNew(SimpleWriteline)
                .ContinueWith(x => Continuation(), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
            return task;
        }

        private static Task CaseD(CancellationToken token)
        {
            token.Register(Continuation, false);
            var task = Task.Factory.StartNew(SimpleWriteline)
                .ContinueWith(x => Continuation(), token);
            return task;
        }

        private static void SimpleWriteline()
        {
            Console.WriteLine("Parent task start");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            //Console.WriteLine("Throw exception");
            //throw new NullReferenceException();
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
