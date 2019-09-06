using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public static class HeapSorting
    {
        public static int Parent(int pIndex)
        {
            if(pIndex == 0)
                return 0;
            
            return pIndex/2;
        }
        public static int Left(int pIndex)
        {
            return 2*pIndex + 1;
        }

        public static int Right(int pIndex)
        {
            return Left(pIndex) + 1;
        }

        public static IList<T> MaxHeapify<T>(this IList<T> pList, int pIndex, int pHeapSize) where T: IComparable
        {
            var leftIndex = Left(pIndex);
            var rightIndex = Right(pIndex);
            int largest = pIndex;
            if(leftIndex < pHeapSize && pList[leftIndex].CompareTo(pList[pIndex]) > 0)
                largest = leftIndex;
            
            if(rightIndex < pHeapSize && pList[rightIndex].CompareTo(pList[largest]) > 0)
                largest = rightIndex;

            if(largest != pIndex)
            {
                pList.Swap(pIndex, largest);
                MaxHeapify(pList, largest, pHeapSize);
            }

            return pList;
        }

        public static IList<T> BuildHeap<T>(this IList<T> pList) where T: IComparable
        {
            for(int i = (pList.Count-1)/2; i >= 0; --i)
            {
                pList.MaxHeapify(i, pList.Count);
            }

            return pList;
        }

        public static IList<T> HeapSort<T>(this IList<T> pList) where T: IComparable
        {
            pList = pList.BuildHeap();

            for(int i = pList.Count - 1; i > 0; --i)
            {
                pList.Swap(0, i);
                pList = pList.MaxHeapify(0, i);
            }
            return pList;
        }

        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)   //This check is not required but Partition function may make many calls so its for perf reason
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}