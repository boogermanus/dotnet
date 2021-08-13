using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadHelper.PrintWithThreadId("Starting Program", true);
            FullySynchronous();
            SpawnAnotherThread();
            UseAsyncAwait();
        }

        static void FullySynchronous()
        {
            IFileHierarchyReader reader = new FileHierarchyReader();
            var content = reader.ReadFileHierarchy("file1a.txt");

            Console.WriteLine($"Result: {content}");
            Console.WriteLine();
        }

        static void SpawnAnotherThread()
        {
            IFileHierarchyReader reader = new FileHierarchyReader();
            Func<string> simpleReadDelegate = () => reader.ReadFileHierarchy("file1a.txt");
            Task<string> simpleReadTask = Task.Run(simpleReadDelegate);
            string result = simpleReadTask.GetAwaiter().GetResult();
            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }

        static void UseAsyncAwait()
        {
            IFileHierarchyReader reader = new FileHierarchyReader();

            Task<string> asyncTaskA = reader.ReadFileHierarchyAsync("file1a.txt");
            Task<string> asyncTaskB = reader.ReadFileHierarchyAsync("file1b.txt");

            Task<string[]> combinedTasks = Task.WhenAll(asyncTaskA, asyncTaskB);

            string[] combinedResult = combinedTasks.GetAwaiter().GetResult();

            combinedResult.ToList().ForEach(t => Console.WriteLine($"Combined Result: {t}"));
        }
    }
}
