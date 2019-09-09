using System;
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
        public LineWidthHistogram AddLine(string pLine)
        {
            if(LineWidths.ContainsKey(pLine.Length))
                LineWidths[pLine.Length]++;
            else
                LineWidths.Add(pLine.Length, 1);
                
            LineCount++;
            return this;
        }

        public int GetLineCountForWidth(int pWidth)
        {
            if (!LineWidths.ContainsKey(pWidth))
                throw new Exception($"No lines for width {pWidth}");
            else
                return LineWidths[pWidth];

        }

        public int GetMedianLineWidth()
        {
            int cumulativeLineCount = 0;

            foreach(var width in OrderedWidths)
            {
                cumulativeLineCount += GetLineCountForWidth(width);

                if(cumulativeLineCount > LineCount/2)
                    return width;
            }

            return 0;
        }
        #endregion
    }
}