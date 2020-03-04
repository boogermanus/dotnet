using System.Collections.Generic;
using FacadePattern.Models;
namespace FacadePattern.Interfaces
{
    public interface IHeroSelector
    {
        Hero GetHero(int heroId);

        // hard to change, will break HeroSelectorBase
        // string SaySomething();
    }
}