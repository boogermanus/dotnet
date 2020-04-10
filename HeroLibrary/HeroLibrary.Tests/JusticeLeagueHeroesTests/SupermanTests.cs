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
    }
}