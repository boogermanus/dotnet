using System;
using System.Collections.Generic;
public static class MergeSorting
{
    public static IList<T> MergeSort<T>(this IList<T> pList, int pFirst, int pLast) where T : IComparable
    {
        if(pLast - pFirst < 1)
            return new List<T>() {pList[pLast]};
        
        var midpoint = (pFirst + pLast)/2;

        var left = pList.MergeSort(pFirst, midpoint);
        var right = pList.MergeSort(midpoint+1, pLast);

        return Merge(left, right);
    }

    public static IList<T> Merge<T>(IList<T> pLeft, IList<T> pRight) where T : IComparable
    {
        var newList = new List<T>();

        while(pLeft.Count != 0 && pRight.Count != 0)
        {
            var leftMin = pLeft[0];
            var rightMin = pRight[0];

            if(leftMin.CompareTo(rightMin) < 0)
            {
                pLeft.RemoveAt(0);
                newList.Add(leftMin);
            }
            else
            {
                pRight.RemoveAt(0);
                newList.Add(rightMin);
            }
        }
        
        newList.AddRange(pLeft);
        newList.AddRange(pRight);

        return newList;
        
    }
}