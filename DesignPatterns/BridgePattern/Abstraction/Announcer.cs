using BridgePattern.Implementer;

namespace BridgePattern.Abstraction
{
    public abstract class Announcer
    {
        public IEntity City;

        public abstract void Announce();
    }
}