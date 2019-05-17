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

            numbers = numbers.MergeSort();

            Assert.That(numbers, Is.EqualTo(new List<int>{1,2,3,4}));
        }

        [Test]
        public void MergeSort_Should_Sort_Hard()
        {
            var random = new System.Random();

            IList<int> randomNumbers = new List<int>();;   

            const int LIMIT = 100;

            for(int i = 0; i < LIMIT; i++)
            {
                randomNumbers.Add(random.Next(0, 100));
            }

            randomNumbers = randomNumbers.OrderBy(i => i).ToList();

            var test = randomNumbers.MergeSort();

            Assert.That(test, Is.EqualTo(randomNumbers));
        }
    }
}