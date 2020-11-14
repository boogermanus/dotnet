using System.Linq;
using HeroLibrary.JusticeLeagueHeros;
using HeroLibrary.Models;
using NUnit.Framework;

namespace HeroLibrary.Tests.JusticeLeagueHeroesTest
{
    [TestFixture]
    public class SupermanTests
    {
        [Test]
        public void SupermanHasNameSuperman()
        {
            var superman = new Superman();

            Assert.That(superman.Name, Is.EqualTo(nameof(Superman)));
        }

        [Test]
        public void SupermanHasCityMetropolis()
        {
            var superman = new Superman();

            Assert.That(superman.City, Is.EqualTo(JusticeLeagueConstants.CITY_METROPOLIS));
        }

        [Test]
        public void SupermanHasAliasClarkKent()
        {
            var superman = new Superman();

            Assert.That(superman.Alias, Is.EqualTo(JusticeLeagueConstants.ALIAS_SUPERMAN));
        }

        [Test]
        public void SupermanHasPowerFlight()
        {
            var superman = new Superman();

            var power = superman.Powers.FirstOrDefault(p => p.Name == PowerConstants.FLIGHT);
            Assert.That(power.Name, Contains.Substring(PowerConstants.FLIGHT));
        }
    }
}