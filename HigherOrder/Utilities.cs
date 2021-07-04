using System;
using System.Diagnostics;

namespace HigherOrder
{
    public class Utilities
    {
        public static void WithLogging(Action work)
        {
            Console.WriteLine("Staring work");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            work();

            stopWatch.Stop();
            Console.WriteLine($"Work completed in {stopWatch.ElapsedMilliseconds}ms");
        }

        public static void Retry(Action work, int times = 1)
        {
            for(var attempts = 0; attempts <= times; attempts++)
            {
                if(attempts > 0)
                    Console.WriteLine($"Attempt #{attempts} to do work...");

                try
                {
                    work();
                    return;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Failed to do work: {e.Message}");
                }
            }

            Console.WriteLine($"Failed to do work after {times} retries.");
        }
    }
}