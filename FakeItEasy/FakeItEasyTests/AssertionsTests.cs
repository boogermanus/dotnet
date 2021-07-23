using System.Collections.Generic;
using System.Net;
using FakeItEasy;
using FakeItEasyDemo.Interfaces;
using FakeItEasyDemo.Models;
using NUnit.Framework;

namespace FakeItEasyTests
{
    [TestFixture]
    public class AssertionsTests
    {
        private IBeerService _service;
        private List<Beer> _beers;
        [SetUp]
        public void SetUp()
        {
            _service = A.Fake<IBeerService>();
            _beers = new List<Beer>()
            {
                new()
                {
                    Id = 1,
                    Name = "Beer 1",
                    Description = "Beer 1",
                    Tagline = "Beer 1",
                    Abv = 1
                },
                new()
                {
                    Id = 1,
                    Name = "Beer 2",
                    Description = "Beer 2",
                    Tagline = "Beer 2",
                    Abv = 2
                },
                new()
                {
                    Id = 1,
                    Name = "Beer 3",
                    Description = "Beer 3",
                    Tagline = "Beer 3",
                    Abv = 1
                }
            };
        }

        [TearDown]
        public void TearDown()
        {
            _service = null;
        }

        [Test]
        public void UsingAnd()
        {
            A.CallTo(() => _service.GetBeers()).Returns(_beers);

            var beers = _service.GetBeers();

            Assert.That(beers, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void UsingOr()
        {
            A.CallTo(() => _service.GetBeers()).Returns(new List<Beer>());

            var beers = _service.GetBeers();
            
            Assert.That(beers, Is.Not.Null.Or.Empty);
            
            // this will fail the test because the list is empty
            // Assert.That(beers, Is.Null.Or.Not.Empty);
        }

        [Test]
        public void UsingContains()
        {
            A.CallTo(() => _service.GetBeers()).Returns(_beers);

            var beers = _service.GetBeers();

            Assert.That(beers, Contains.Item(_beers[0]));
        }

        [Test]
        public void ExceptionWithMessage()
        {
            const string message = "id cannot be negative";
            
            A.CallTo(() => _service.GetBeer(-1)).Throws(new WebException(message));

            Assert.That(() => _service.GetBeer(-1), Throws.InstanceOf<WebException>().With.Message.EqualTo(message));
        }
    }
}