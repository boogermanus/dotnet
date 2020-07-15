using MediatorPattern.Colleagues;
using MediatorPattern.Models;

namespace MediatorPattern.Mediators
{
    public interface IHeroMediator
    {
        void SendMessage(Hero sender, string message, Hero target);
    }
}