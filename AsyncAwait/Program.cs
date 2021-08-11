using System;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadHelper.PrintWithThreadId("Starting Program", true);
            FullySynchronous();
        }

        static void FullySynchronous()
        {
            IFileHierarchyReader reader = new FileHierarchyReader();
            var content = reader.ReadFileHierarchy("file1a.txt");

            Console.WriteLine($"Result: {content}");
            Console.WriteLine();
        }
    }
}
