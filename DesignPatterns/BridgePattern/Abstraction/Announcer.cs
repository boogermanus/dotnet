using BridgePattern.Implementer;

namespace BridgePattern.Abstraction
{
    public abstract class Announcer
    {
        public IHero Hero;

        public abstract void Announce();
    }
}