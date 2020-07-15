using MediatorPattern.Colleagues;

namespace MediatorPattern.Mediators
{
    public interface Mediator
    {
        void SendMessage(string message, ConcessionStand concessionStand);
    }
}