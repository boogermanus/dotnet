using System;
using System.Collections.Generic;
public static class MergeSorting
{
    #region Constants
    private const int ONE = 1;
    // throw back to admiral spruence and his victory at Midway
    private const int MIDWAY = 2;
    #endregion
    
    #region Methods

    // making methods 'where T : IComparable makes using the Comparer.Default unnecessary
    #region MergeSort
    public static IList<T> MergeSort<T>(this IList<T> pList, int pFirst, int pLast) where T : IComparable
    {
        // if the element indexs are 0, return a new list
        if(pLast - pFirst < ONE)
            return new List<T>() {pList[pLast]};
        
        // find the 'Midway' point of the list
        // note: this is integer division; no decimals here
        var midpoint = (pFirst + pLast)/MIDWAY;

        // recursive calls to sort
        var left = pList.MergeSort(pFirst, midpoint);
        var right = pList.MergeSort(midpoint+1, pLast);

        // merage the result
        return Merge(left, right);
    }

    public static IList<T> MergeSort<T>(this IList<T> pList) where T : IComparable
    {
        // just do the same thing as above
        return pList.MergeSort(0, pList.Count - ONE);
    }

    #endregion

    #region Merge
    private static IList<T> Merge<T>(IList<T> pLeft, IList<T> pRight) where T : IComparable
    {
        var newList = new List<T>();

        // because we are removing elements from the list
        // we are still saving memory
        while(pLeft.Count != 0 && pRight.Count != 0)
        {
            // this is all ari, he's genius
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

        // add what is left to our return list
        // TODO argue with Ari about memory
        newList.AddRange(pLeft);
        newList.AddRange(pRight);

        return newList;
        
    }
    #endregion

    #endregion // methods
}