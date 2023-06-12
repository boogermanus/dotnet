using BridgePattern.Implementer;

namespace BridgePattern.Abstraction
{
    public abstract class Announcer
    {
        public IEntity Hero;

        // now we can pass multiple interfaces
        // a minimal change
        public IEntity SideKick;

        public abstract void Announce();

        // hard to add again without adding to all
        // all classes that descend from Announcer
        // public abstract void AnnounceWithSideKick();

        // can add virtual method without issue
        public virtual void DoSomething()
        {

        }
    }
}