using System.Collections.Generic;

namespace Analyzer
{
    public class LineWidthHistogram
    {
        public Dictionary<int, int> LineWidths { get; set; } = new Dictionary<int, int>();
        public int LineCount { get; set; }

        public void AddLine(string pLine)
        {
            if(LineWidths.ContainsKey(pLine.Length))
                LineWidths[pLine.Length]++;
            else
                LineWidths.Add(pLine.Length, 1);
                
            LineCount++;
        }
    }
}