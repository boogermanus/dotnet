using System;
using System.Collections.Generic;
public static class MergeSorting
{
    private const int ONE = 1;
    private const int HALF = 2;
    public static IList<T> MergeSort<T>(this IList<T> pList, int pFirst, int pLast) where T : IComparable
    {
        // if the element indexs are 0, return a new list
        if(pLast - pFirst < ONE)
            return new List<T>() {pList[pLast]};
        
        // find the 'half way' point of the list
        // note: this is integer division; no decimals here
        var midpoint = (pFirst + pLast)/HALF;

        // recursive calls to sort
        var left = pList.MergeSort(pFirst, midpoint);
        var right = pList.MergeSort(midpoint+1, pLast);

        // merage the result
        return Merge(left, right);
    }

    public static IList<T> MergeSort<T>(this IList<T> pList) where T : IComparable
    {
        return pList.MergeSort(0, pList.Count - ONE);
    }

    private static IList<T> Merge<T>(IList<T> pLeft, IList<T> pRight) where T : IComparable
    {
        var newList = new List<T>();

        // because we are removing elements from the list
        // we are still saving memeory
        while(pLeft.Count != 0 && pRight.Count != 0)
        {
            // take the first element from each list
            var leftMin = pLeft[0];
            var rightMin = pRight[0];

            if(leftMin.CompareTo(rightMin) < 0)
            {
                // leftMin < rightMin
                pLeft.RemoveAt(0);
                newList.Add(leftMin);
            }
            else
            {
                // leftMin > rightMin
                pRight.RemoveAt(0);
                newList.Add(rightMin);
            }
        }
        
        // add what is left
        newList.AddRange(pLeft);
        newList.AddRange(pRight);

        return newList;
        
    }
}