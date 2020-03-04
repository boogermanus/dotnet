using System;
using BridgePattern.Abstraction;


namespace BridgePattern.ConcreteImplementer
{
    public class CentralCity : Announcer
    {
        public override void Announce()
        {
            Hero.Introduce("In Central City our hero is");
        }
    }
}