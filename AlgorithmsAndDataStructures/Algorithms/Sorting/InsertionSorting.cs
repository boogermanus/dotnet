using System.Collections.Generic;
namespace Algorithms.Sorting
{
    public static class InsertionSorting
    {
        public static IList<T> InsertionSort<T>(this IList<T> pList)
        {
            int i, j;
            var comparer = Comparer<T>.Default;

            for(i = 1; i < pList.Count; i++)
            {
                T value = pList[i];
                j = i - 1;

                while(j >= 0 && comparer.Compare(pList[j], value) > 0)
                {
                    pList[j + 1] = pList[j];
                    j--;
                }

                pList[j + 1] = value;
            }

            return pList;
        }
    }
}