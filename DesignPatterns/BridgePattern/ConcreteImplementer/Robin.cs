using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class Robin : IEntity
    {
        public void Introduce(string cityText)
        {
            Console.WriteLine($"{cityText} {nameof(Robin)}");
        }
    }
}