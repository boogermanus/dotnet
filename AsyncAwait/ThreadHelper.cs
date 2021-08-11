using System;
using System.Threading;

namespace AsyncAwait
{
    public class ThreadHelper
    {
        public static void PrintWithThreadId(string message, bool extraLine = false)
        {
            Console.WriteLine($"{message} on thread:{Thread.CurrentThread.ManagedThreadId}");

            if (extraLine)
                Console.WriteLine();
        }
    }
}