using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using Algorithms.Sorting;

namespace Tests.Sorting 
{
    [TestFixture]
    public class MergeSortingTests
    {
        [Test]
        public void MergeSort_Should_Sort()
        {
            IList<int> numbers = new List<int> {2, 4, 1, 3};

            numbers = numbers.MergeSort(0, numbers.Count - 1);

            Assert.That(numbers, Is.EqualTo(new List<int>{1,2,3,4}));
        }
    }
}