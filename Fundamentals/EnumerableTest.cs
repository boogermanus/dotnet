using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Fundamentals
{
    public class EnumerableTest : IDemo
    {
        
        public void Run()
        {
            DoEnumerable();
        }
        private void DoEnumerable()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiple iterations.
            var allItems = GetNumbersEnumerableFor().ToList();
            // allItems = GetNumbersEnumerableWhile().ToList();
            // allItems = GetNumbersList().ToList();
            
            LogTime(stopwatch, nameof(allItems));
            
            var largerThan5 = allItems.Where(i => i > 5);
            LogTime(stopwatch, nameof(largerThan5));
            
            var largerThan5InOrder = largerThan5.OrderBy(i => i);
            LogTime(stopwatch, nameof(largerThan5InOrder));
            
            foreach (var i in largerThan5InOrder)
            {
            }
            
            LogTime(stopwatch, $"foreach on {nameof(largerThan5InOrder)}");
            
            var largest = allItems.Max();
            LogTime(stopwatch, nameof(largest));
            
            var count = allItems.Count();
            LogTime(stopwatch, nameof(count));
            
            var largerThan5InOrderArray = largerThan5InOrder.ToArray();
            LogTime(stopwatch, nameof(largerThan5InOrderArray));
            
            
            var grouping = allItems.GroupBy(n => n);
            LogTime(stopwatch, nameof(grouping));
            
            var lookup = allItems.ToLookup(n => n, n => new[] { n });
            LogTime(stopwatch, nameof(lookup));
            
            var dict = allItems.ToDictionary(n => n, n => new[] { n });
            LogTime(stopwatch, nameof(dict));
        }

        private  IEnumerable<int> GetNumbersEnumerableFor()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return GetItem(i);
            }
            
        }

        private IEnumerable<int> GetNumbersEnumerableWhile()
        {
            var i = 0;
            while (true)
            {
                if (i < 10)
                    yield return GetItem(i);
                else
                    yield break;
                i++;
            }
        }

        private IList<int> GetNumbersList()
        {
            var items = new int[10];
            for (var i = 0; i < 10; i++)
            {
                items[i] = GetItem(i);
            }
            return items;
        }

        
        private int GetItem(int i)
        {
            Thread.Sleep(200);
            return i;
        }

        private void LogTime(Stopwatch stopwatch, string label)
        {
            stopwatch.Stop();
            Console.WriteLine($"{label} {stopwatch.Elapsed}");
            stopwatch.Restart();
        }


    }
}