using System;
using BridgePattern.Abstraction;
using BridgePattern.Implementer;

namespace BridgePattern.RefinedAbstraction
{
    public class Flash : IEntity
    {
        public void Introduce(string cityText)
        {
            Console.WriteLine($"{cityText} Flash");
        }
    }
}