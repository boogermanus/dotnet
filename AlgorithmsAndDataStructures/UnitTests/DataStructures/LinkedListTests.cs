using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using DataStructures.Basic;

namespace Tests.DataStructures
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Print_Should_Print_List()
        {
            var items = new[] {1, 2};
            var list = new LinkedList<int>();
            list.Append(1);
            list.Append(2);

            Assert.That(list.Print(), Is.EqualTo(string.Join(',', items)));
        }
    }
}