using System.Linq;
using System.Collections.Generic;

namespace Analyzer
{
    public class LineWidthHistogram
    {
        #region Members
        public Dictionary<int, int> LineWidths { get; set; } = new Dictionary<int, int>();
        public int LineCount { get; set; }
        public int WidestLine => OrderedWidths.OrderByDescending(i => i).FirstOrDefault();

        public List<int> OrderedWidths => LineWidths.Keys.OrderBy(i => i).ToList();
        #endregion
        #region Methods
        public void AddLine(string pLine)
        {
            if(LineWidths.ContainsKey(pLine.Length))
                LineWidths[pLine.Length]++;
            else
                LineWidths.Add(pLine.Length, 1);
                
            LineCount++;
        }
        #endregion
    }
}