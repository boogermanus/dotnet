using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using DataStructures.Basic;

namespace Test.DataStructures
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Pop_Should_Return_Null_For_EmptyStack()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.Pop(), Throws.Exception);
        }

        [Test]
        public void Pop_Should_Return_Items_Then_Throw()
        {
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);

            Assert.That(() => stack.Pop(), Is.EqualTo(20));
            Assert.That(() => stack.Pop(), Is.EqualTo(10));
            Assert.That(() => stack.Pop(), Throws.Exception);
        }

        [Test]
        public void Push_Should_Add_Item()
        {
            var stack = new Stack<int>();

            stack.Push(10);

            Assert.That(stack.Count, Is.EqualTo(1));
        }
    }
}