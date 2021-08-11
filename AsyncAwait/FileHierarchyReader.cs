using System.IO;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class FileHierarchyReader : IFileHierarchyReader
    {
        private const string BASE_DATA_PATH = "Data/";
        public string ReadFileHierarchy(string file)
        {
            ThreadHelper.PrintWithThreadId("Starting Read");

            var path = Path.Combine(BASE_DATA_PATH, file);
            string file2Name = File.ReadAllText(path);

            ThreadHelper.PrintWithThreadId($"Got second file name: {file2Name}");

            path = Path.Combine(BASE_DATA_PATH, file2Name);
            string file3Name = File.ReadAllText(path);

            ThreadHelper.PrintWithThreadId($"Got third file name: {file3Name}");
            path = Path.Combine(BASE_DATA_PATH, file3Name);
            string file3Contents = File.ReadAllText(path);

            return file3Contents;
        }

        public Task<string> ReadFileHierarchyAsync(string file)
        {
            throw new System.NotImplementedException();
        }
        
        
    }
}