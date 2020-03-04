using System;
using BridgePattern.Abstraction;
using BridgePattern.Implementer;

namespace BridgePattern.RefinedAbstraction
{
    public class Flash : Announcer
    {
        public override void Announce()
        {
            City.Introduce("Flash");
        }
    }
}