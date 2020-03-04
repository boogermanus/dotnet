using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class CentralCity : IEntity
    {
        public void Introduce(string name)
        {
            Console.WriteLine($"In Central City our hero is {name}");
        }
    }
}