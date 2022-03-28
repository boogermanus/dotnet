using System;
using System.Collections.Generic;
using FakeItEasy;
using FakeItEasyDemo.Interfaces;
using FakeItEasyDemo.Models;
using FakeItEasyDemo.Services;
using NUnit.Framework;

namespace FakeItEasyTests
{
    [TestFixture]
    public class DependentServiceTests
    {
        private IDependentService _dependentService;
        private IBeerService _fakeBeerService;
        private List<Beer> _beers;
        
        [SetUp]
        public void SetUp()
        {
            _fakeBeerService = A.Fake<IBeerService>();
            _dependentService = new DependentService(_fakeBeerService);
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
            _dependentService = null;
            _fakeBeerService = null;
        }

        [Test]
        public void AssertThatACallWasMadeToGetBeers()
        {
            _dependentService.GetTotalAbv();
            A.CallTo(() => _fakeBeerService.GetBeers()).MustHaveHappened();
        }

        [Test]
        public void ExampleOfUsingReturn()
        {
            A.CallTo(() => _fakeBeerService.GetBeers()).Returns(new[] {new Beer() {Abv = 1}});

            Assert.That(() => _dependentService.GetTotalAbv(), Is.EqualTo(1));
        }

        [Test]
        public void ExampleWithoutSpecifyingAReturn()
        {
            var beer = _dependentService.GetBeerAbv(1);

            // the fake service will return a dummy beer by default
            Assert.That(beer, Is.EqualTo(decimal.Zero));
        }

        [Test]
        public void ExampleOfReturnNextFromSequence()
        {
            A.CallTo(() => _fakeBeerService.GetBeer(A<int>.Ignored)).ReturnsNextFromSequence(_beers.ToArray());

            for (int i = 0; i < _beers.Count; ++i)
            {
                var abv = _dependentService.GetBeerAbv(i);
                Assert.That(abv, Is.EqualTo(_beers[i].Abv));
            }
        }

        [Test]
        public void ExampleOfReturnsLazilyWithParameter()
        {
            A.CallTo(() => _fakeBeerService.GetBeer(A<int>.Ignored)).ReturnsLazily((int i) => new Beer {Id = i, Abv = 10});

            Assert.That(() => _dependentService.GetBeerAbv(1), Is.EqualTo(10));
        }

        [Test]
        public void ExampleOfADummy()
        {
            A.CallTo(() => _fakeBeerService.GetBeer(A<int>.Ignored)).Returns(A.Dummy<Beer>());

            Assert.That(() => _dependentService.GetBeerAbv(20), Is.EqualTo(0));
        }

        [Test]
        public void ExampleOfHowToThrow()
        {
            A.CallTo(() => _fakeBeerService.GetBeers()).Throws(new Exception());

            Assert.That(() => _dependentService.GetTotalAbv(), Throws.Exception);
        }

        [Test]
        public void ExampleOfHowToThrowConditionally()
        {
            A.CallTo(() => _fakeBeerService.GetBeer(-1)).Throws<Exception>();

            Assert.That(() => _dependentService.GetBeerAbv(1), Throws.Nothing);
            Assert.That(() => _dependentService.GetBeerAbv(-1), Throws.Exception);
        }
        
        [Test]
        public void AnotherExampleOfHowToThrowConditionally()
        {
            // this is more powerful then the above line as you can do custom logic
            A.CallTo(() => _fakeBeerService.GetBeer(A<int>.Ignored)).ReturnsLazily((int i) =>
            {
                if (i < 0)
                    throw new Exception();

                return A.Dummy<Beer>();
            });

            Assert.That(() => _dependentService.GetBeerAbv(1), Throws.Nothing);
            Assert.That(() => _dependentService.GetBeerAbv(-1), Throws.Exception);
        }

        [Test]
        public void YetAnotherExampleOfHowToThrowConditionally()
        {
            A.CallTo(() => _fakeBeerService.GetBeer(A<int>.Ignored))
                .WhenArgumentsMatch((int i) => i.Equals(-1))
                .Throws<Exception>();
            
            Assert.That(() => _dependentService.GetBeerAbv(1), Throws.Nothing);
            Assert.That(() => _dependentService.GetBeerAbv(-1), Throws.Exception);
        }
    }
}