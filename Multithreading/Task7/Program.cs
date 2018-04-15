using System;
using System.Threading;
using Task7.Command;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = GetTaskCommand();
            if (command != null)
            {
                using (var cancellationTokenSource = new CancellationTokenSource())
                {
                    ExecuteTaskCommand(command, cancellationTokenSource.Token);
                }
            }
            Console.ReadKey();
        }

        private static ITaskCommand GetTaskCommand()
        {
            ITaskCommand result = null;
            Console.WriteLine("Enter command key");
            var tcm = new TaskCommandManager();
            var key = Console.ReadLine();
            try
            {
                result = tcm.GetCommand(key);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        private static void ExecuteTaskCommand(ITaskCommand command, CancellationToken token)
        {
            try
            {
                Console.WriteLine("Create and start Task");
                var task = command.ExecuteCommand(token);
                task.Wait(token);
                Console.WriteLine("End Task");
            }
            catch (Exception e)
            {
                if (e is ArgumentException || e is OperationCanceledException)
                    Console.WriteLine(e.Message);
                else if (e is AggregateException)
                {
                    foreach (var item in ((AggregateException)e).InnerExceptions)
                        if (item is OperationCanceledException)
                            Console.WriteLine(item.Message);
                        else
                            Console.WriteLine("Unhandled exception. " + e);
                }
                else
                    Console.WriteLine("Unhandled exception. " + e);
            }
        }
    }
}
