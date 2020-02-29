using System.Collections.Generic;
using FacadePattern.Models;
namespace FacadePattern.Interfaces
{
    public interface IHeroMember
    {
        Hero GetHero(int heroId);
    }
}