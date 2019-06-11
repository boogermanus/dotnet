using System;
using System.Collections.Generic;
namespace Algorithms.Sorting
{

    public static class QuickSorting
    {
        public static int Partition<T>(this IList<T> pList, int pStartIndex, int pEndIndex) where T : IComparable
        {
            var pivot = pList[pEndIndex];
            var index = pStartIndex - 1;

            for (int j = pStartIndex; j < pEndIndex; j++)
            {
                if (pList[j].CompareTo(pivot) <= 0)
                {
                    index++;
                    pList.Swap(index, j);
                }
            }

            pList.Swap(index + 1, pEndIndex);

            return index + 1;
        }

        public static IList<T> QuickSort<T>(this IList<T> pList, int pStartIndex, int pEndIndex) where T : IComparable
        {
            if(pStartIndex < pEndIndex)
            {
                var pivot = pList.Partition(pStartIndex, pEndIndex);
                pList.QuickSort(pStartIndex, pivot - 1);
                pList.QuickSort(pivot + 1, pEndIndex);
            }
            
            return pList;
        }

        public static IList<T> QuickSort<T>(this IList<T> pList) where T : IComparable
        {
            return pList.QuickSort(0, pList.Count - 1);
        }
    }
}