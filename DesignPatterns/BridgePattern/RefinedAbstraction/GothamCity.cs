using BridgePattern.Abstraction;

namespace BridgePattern.RefinedAbstraction
{
    public class GothamCity : Announcer
    {
        public override void Announce()
        {
            Hero.Introduce("We're Gotham City and our Dark Knight is");
            // we can easily do something with our new interface here
            SideKick.Introduce("And the Boy Wonder is");
        }
    }
}