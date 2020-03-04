using System;
using BridgePattern.Abstraction;
using BridgePattern.Implementer;

namespace BridgePattern.RefinedAbstraction
{
    public class Robin : IEntity
    {
        public void Introduce(string cityText)
        {
            Console.WriteLine($"{cityText} {nameof(Robin)}");
        }
    }
}