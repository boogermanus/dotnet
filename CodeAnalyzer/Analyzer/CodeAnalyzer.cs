using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Analyzer
{
    public class CodeAnalyzer
    {
        private string _rootDirectoryPath;
        private string _fileFilter = "*.cs"; // default to C# files
        private LineWidthHistogram _histogram = new LineWidthHistogram();

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

        public void Analyze()
        {
            List<string> filesToAnalyze = GetFilesToAnalyze();

            IEnumerable<LineWidthHistogram> histograms = filesToAnalyze
                .Select(file => GetHistogramForFile(file));

            foreach(var histogram in histograms)
                _histogram.Combine(histogram);
        }

        private List<string> GetFilesToAnalyze()
        {
            return Directory
                .GetFiles(_rootDirectoryPath, _fileFilter, SearchOption.AllDirectories)
                .ToList();
        }

        private static LineWidthHistogram GetHistogramForFile(string pFullFilePath)
        {
            var histogram = new LineWidthHistogram();
            
            File
                .ReadAllLines(pFullFilePath)
                .ToList()
                .ForEach(line => histogram.AddLine(line));

            return histogram;
        }
    }
}