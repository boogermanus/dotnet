using System;
using FacadePattern.Interfaces;
using FacadePattern.Models;

namespace FacadePattern.Subsystem
{
    public abstract class HeroSelectorBase : IHeroSelector
    {
        private HeroCollection _heroes = new HeroCollection();
        public Hero GetHero(int heroId)
        {
            return _heroes.Heros[--heroId];
        }
    }
}