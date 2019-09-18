using System;
using System.Collections.Generic;
using System.IO;
namespace Analyzer
{
    public class CodeAnalyzer
    {
        private string _rootDirectoryPath;
        private string _fileFilter = "*.cs"; // default to C# files

        public CodeAnalyzer(string pRootDirectoryPath, string pFileFilter = null)
        {
            _rootDirectoryPath = GetDirectoryPath(pRootDirectoryPath);
            _fileFilter = pFileFilter ?? _fileFilter;
        }

        private string GetDirectoryPath(string pRootDirectoryPath)
        {
            if(string.IsNullOrWhiteSpace(pRootDirectoryPath))
                throw new ArgumentException($"{pRootDirectoryPath} is not a valid path", nameof(pRootDirectoryPath));
            if(!Directory.Exists(pRootDirectoryPath))
                throw new ArgumentException($"{pRootDirectoryPath} not found");

            // return the full path name of the specified directory even if
            // the path was relative.
            return new DirectoryInfo(pRootDirectoryPath).FullName;
        }
    }
}