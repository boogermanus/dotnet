using System;

namespace PrototypePattern.ConcretePrototype
{
    public class Hero : ICloneable
    {
        public string Name {get;}
        public string City {get;}
        
        public Hero(string name, string city)
        {
            Name = name;
            City = city;
        }

        public object Clone()
        {
            Console.WriteLine($"Cloning Hero: {Name}");
            return MemberwiseClone();
        }
    }
}