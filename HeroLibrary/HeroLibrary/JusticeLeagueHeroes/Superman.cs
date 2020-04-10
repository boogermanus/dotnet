using HeroLibrary.Models;

namespace HeroLibrary.JusticeLeagueHeros
{
    public class Superman : Hero
    {
        public override void ImagineHero()
        {
            Name = nameof(Superman);
            City = JusticeLeagueConstants.CITY_METROPOLIS;
            Alias = JusticeLeagueConstants.ALIAS_SUPERMAN;
        }
    }
}