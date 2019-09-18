using System;
using System.Collections.Generic;
using System.IO;
namespace Analyzer
{
    public class CodeAnalyzer
    {
        private string _rootDirectoryPath;
        private string _fileFilter = "*.cs";

        public CodeAnalyzer(string pRootDirectoryPath, string pFileFilter = null)
        {
            CheckDirectoryPath(pRootDirectoryPath);
            _rootDirectoryPath = pRootDirectoryPath;
            _fileFilter = pFileFilter ?? _fileFilter;
        }

        private void CheckDirectoryPath(string pRootDirectoryPath)
        {
            if(string.IsNullOrWhiteSpace(pRootDirectoryPath))
                throw new ArgumentException($"{pRootDirectoryPath} is not a valid path", nameof(pRootDirectoryPath));
            if(!Directory.Exists(pRootDirectoryPath))
                throw new ArgumentException($"{pRootDirectoryPath} not found");
        }
    }
}