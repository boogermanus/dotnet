using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class Flash : IEntity
    {
        public void Introduce(string cityText)
        {
            Console.WriteLine($"{cityText} Flash");
        }
    }
}