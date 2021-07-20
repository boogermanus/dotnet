using FakeItEasy;
using FakeItEasyDemo.Interfaces;
using FakeItEasyDemo.Services;
using NUnit.Framework;

namespace FakeItEasyTests
{
    [TestFixture]
    public class FakeItEasyServiceTests
    {
        private IFakeItEasyService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new FakeItEasyService();
        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
        }

        [Test]
        public void IncrementCountIncrementsCountByOne()
        {
            _service.IncrementCount();

            Assert.That(_service.GetCount(), Is.EqualTo(1));
        }

        [Test]
        public void IncrementCountByIncrementsByTwo()
        {
            _service.IncrementCountBy(2);

            Assert.That(_service.GetCount(), Is.EqualTo(2));
        }

        [Test]
        public void IncrementCountIncrementsByFakeItEasy()
        {
            var service = A.Fake<IFakeItEasyService>();

            A.CallTo(() => service.GetCount()).Returns(10);

            Assert.That(service.GetCount(), Is.EqualTo(10));
        }
    }
}