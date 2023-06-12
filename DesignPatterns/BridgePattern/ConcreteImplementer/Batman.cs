using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class Batman : IEntity
    {
        public void Introduce(string cityText)
        {
            Console.WriteLine($"{cityText} {nameof(Batman)}");
        }
    }
}