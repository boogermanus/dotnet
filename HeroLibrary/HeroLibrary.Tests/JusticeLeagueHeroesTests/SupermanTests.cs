using HeroLibrary.JusticeLeagueHeros;
using NUnit.Framework;

namespace HeroLibrary.Tests.JusticeLeagueHeroesTest
{
    [TestFixture]
    public class SupermanTests
    {
        [Test]
        public void SupermanHasNameSupermane()
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
    }
}