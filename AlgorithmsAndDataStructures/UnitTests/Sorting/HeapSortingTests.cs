using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using Algorithms.Sorting;

namespace Tests.Sorting
{
    [TestFixture]
    public class HeapSortingtests
    {
        [Test]
        public void MaxHeapify_Should_Heap()
        {
            IList<int> list = new List<int> {4,1,3,2,16,9,10,14,8,7};

            list = list.BuildHeap();

            for(int i = 0;i<list.Count -1;++i)
            {
                var leftIndex = HeapSorting.Left(i);
                var rightIndex = HeapSorting.Right(i);

                if(leftIndex < list.Count)
                    Assert.That(list[i] >= list[leftIndex], $"{list[i]} > {list[leftIndex]}");

                if(rightIndex < list.Count)
                    Assert.That(list[i] >= list[rightIndex], $"{list[i]} > {list[rightIndex]}");
            }
        }

        [Test]
        public void HeapSort_Should_Sort()
        {
            IList<int> list = new List<int> {4,1,3,2,16,9,10,14,8,7};
            IList<int> ordered = list.OrderBy(i=> i).ToList();

            list = list.HeapSort();

            Assert.That(list, Is.EqualTo(ordered));
        }
    }
}