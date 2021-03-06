using System;
using System.Collections.Generic;
namespace Algorithms.Sorting
{
    public static class InsertionSorting
    {
        // making methods 'where T : IComparable makes using the Comparer.Default unnecessary
        public static IList<T> InsertionSort<T>(this IList<T> pList) where T : IComparable
        {
            int i, j;

            // start at the second element
            for(i = 1; i < pList.Count; i++)
            {
                // get the secord element
                T value = pList[i];

                // choose the first index to compare it to
                j = i - 1;

                // if the value is greater than swap and repeat
                
                while(j >= 0 && pList[j].CompareTo(value) > 0)
                {
                    pList[j + 1] = pList[j];
                    j--;
                }

                // finally, just swap the last value
                pList[j + 1] = value;
            }

            return pList;
        }
    }
}