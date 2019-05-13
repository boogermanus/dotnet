using NUnit.Framework;
using System.Collections.Generic;
using Algorithms.Sorting;

namespace Tests.Sorting 
{
    [TestFixture]
    public class InsertionSortingTests
    {
        [Test]
        public void InsertionSort_Should_Sort()
        {
            IList<int> numbers = new List<int> {2, 4, 1, 3};

            numbers = numbers.InsertionSort();

            Assert.That(numbers, Is.EqualTo(new List<int>{1,2,3,4}));
        }
    } 
}