using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using Algorithms.Sorting;

namespace Tests.Sorting 
{
    [TestFixture]
    public class QuickSortingTests
    {

        [Test]
        public void Partition_Should_Partition()
        {
            var list = new List<int> {2,8,7,1,3,5,6,4};

            Assert.That(() => list.Partition(0, list.Count-1), Is.EqualTo(3));
        }

        [Test]
        public void QuickSort_Should_Sort()
        {
            var list = new List<int> {2,8,7,1,3,5,6,4};
            var mySort = list.QuickSort();
            var netSort = list.OrderBy(i => i).ToList();

            Assert.That(mySort, Is.EqualTo(netSort));
        }
    }
}