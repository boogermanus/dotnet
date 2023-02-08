using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Fundamentals
{
    public class StringConcatenation
    {
        internal void Test()
        {
        }

        private void BuildWithConstantStrings(string middlePart)
        {
            var s1 = "This is a long sentence asdlfkja sdlkfjaslkdfja lskdfjalsd kj" +
                   "asldkjf alksjdf alskdjflaksdjf alskdjfalksdjf alskdjfalskdjf asdf" +
                   "asldkfj aslkdjfalskdjfalskdjfalskdjal sdjfalsk dj" + 
                   middlePart +
                   "This is the last part" +
                   "really" +
                   "I am done";
            
            // Don't do this
            var s2 = string.Concat(string.Concat("This is a long sentence asdlfkja sdlkfjaslkdfja lskdfjalsd kj",
                    "asldkjf alksjdf alskdjflaksdjf alskdjfalksdjf alskdjfalskdjf asdf",
                    "asldkfj aslkdjfalskdjfalskdjfalskdjal sdjfalsk dj"),
                middlePart,
                string.Concat("This is the last part",
                    "really",
                    "I am done"));
            
            // Don't use StringBuilder here
        }

        private void BuildWithVariables(string p1, string p2, string p3, string p4)
        {
            var s1 = p1 + p2 + p3 + p4;

            var s2 = string.Concat(p1, p2, p3, p4);

            var s3 = $"{p1}{p2}{p3}{p4}";
            var s4 = string.Format("{0}{1}{2}{3}", p1, p2, p3, p4);

            // Don't use StringBuilder here
        }

        private void BuildWithMoreVariables(string p1, string p2, string p3, string p4, string p5)
        {
            var s1 = p1 + p2 + p3 + p4 + p5;

            var s2 = string.Concat(new[] { p1, p2, p3, p4, p5 });
            
            var s3 = string.Concat(p1, p2, p3, p4, p5);
            // Don't use StringBuilder here
        }

        private void BuildWithDelimiter(string delimiter, string p1, string p2, string p3, string p4, string p5)
        {
            var s1 = p1 + delimiter + p2 + delimiter + p3 + delimiter + p4 + delimiter + p5;

            var s2 = string.Concat(p1, delimiter, p2, delimiter, p3, p4, delimiter, p5);

            var s3 = string.Join(delimiter, p1, p2, p3, p4, p5);
        }

        private void BuildStringWithComplexLogic(bool doThis, bool notThis, DataRow row, DateTime dateTime)
        {
            var builder = new StringBuilder();

            if (doThis)
                builder.Append("I need to do this");
            
            if(notThis)
                builder.Append("I should not do this");
            
            if (row["Column"] == DBNull.Value)
                builder.Append("value is missing");
            
            if (dateTime < DateTime.Now)
                builder.Append("Expired");
            
            var s = builder.ToString();
        }
        
        private void BuildStringWithALotOfParts(DataRow[] rows)
        {
            var builder = new StringBuilder();

            foreach (var row in rows)
            {
                builder.Append(row["StringColumn"]);
            }
            
            var s = builder.ToString();
        }

        private void BuildWithAggregate(IEnumerable<string> parts)
        {
            var s1 = parts.Aggregate((current, newPart) => $"{current},{newPart}");
            
            var s2 = parts.Aggregate("", (current, newPart) => $"{current},{newPart}");

            var s3 = string.Join(",", parts);
        }
    }
}