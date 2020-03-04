using BridgePattern.Implementer;

namespace BridgePattern.Abstraction
{
    public abstract class Announcer
    {
        public IEntity Hero;

        public abstract void Announce();
    }
}