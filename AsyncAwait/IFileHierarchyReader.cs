using System.Threading.Tasks;

namespace AsyncAwait
{
    public interface IFileHierarchyReader
    {
        string ReadFileHierarchy(string file);
        Task<string> ReadFileHierarchyAsync(string file);
    }
}