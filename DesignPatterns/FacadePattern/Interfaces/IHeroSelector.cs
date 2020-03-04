using FacadePattern.Models;
namespace FacadePattern.Interfaces
{
    public interface IHeroSelector
    {
        Hero GetHero(int heroId);

        // sort of easy change, will break HeroSelectorBase
        // but just needs an override.
        // string SaySomething();
    }
}