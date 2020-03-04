using System.Text;
using System.Collections.Generic;
using FacadePattern.Services;
using FacadePattern.Models;
namespace FacadePattern.Facades
{
    public class HeroTeamFacade
    {
        private List<HeroSelectorBase> _selectors = new List<HeroSelectorBase>
        {
            new FirstHeroSelector(),
            new SecondHeroSelector(),
            new ThirdHeroSelector(),
            // easy to add a new Selector
            new FirstHeroSelector(),
        };

        public string GetHeroTeam(HeroConfig config)
        {
            var firstHero = _selectors[0].GetHero(config.FirstHeroId);
            var secondHero = _selectors[1].GetHero(config.SecondHeroId);
            var thirdHero = _selectors[2].GetHero(config.ThirdHeroId);

            return new StringBuilder()
                .AppendLine("Your Hero Team!")
                .AppendLine($"1: {firstHero.Name}")
                .AppendLine($"2: {secondHero.Name}")
                .AppendLine($"3: {thirdHero.Name}")
                .ToString();
            
        }
    }
}