using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class CentralCity : IHero
    {
        public void Introduce(string name)
        {
            Console.WriteLine($"In Central City our hero is {name}");
        }
    }
}