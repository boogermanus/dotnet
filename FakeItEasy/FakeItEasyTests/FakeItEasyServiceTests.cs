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
        private IFakeItEasyService _fakeService;
        
        [SetUp]
        public void SetUp()
        {
            _service = new FakeItEasyService();
            _fakeService = A.Fake<IFakeItEasyService>();

        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
            _fakeService = null;
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

        [Test]
        public void GetCountWithOptionReturnsZero()
        {
            Assert.That(() => _service.GetCount("zero"), Is.EqualTo(0));
        }

        [Test]
        public void GetCountWithOptionReturnsTen()
        {
            A.CallTo(() => _fakeService.GetCount(A<string>.Ignored))
                .ReturnsLazily((string option) => option == "ten" ? 10 : 0);

            Assert.That(() => _fakeService.GetCount("ten"), Is.EqualTo(10));
        }

        [Test]
        public void GetCountWithOptionAlsoReturnsTen()
        {
            A.CallTo(() => _fakeService.GetCount("ten"))
                .Returns(10);

            Assert.That(() => _fakeService.GetCount("ten"), Is.EqualTo(10));
        }
    }
}