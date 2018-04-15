using System;
using System.Threading;

namespace Task7
{
    public class ConsoleActions
    {
        public static void WriteConsoleChild()
        {
            WriteConsole("Child");
        }

        public static void WriteConsoleParent()
        {
            WriteConsole("Parent");
        }

        private static void WriteConsole(string actor)
        {
            Console.WriteLine($"{actor} task start");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"{actor} task end");
        }
    }
}
