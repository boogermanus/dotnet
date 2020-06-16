using System.Collections.Generic;
using DecoratorPattern.Component;

namespace DecoratorPattern.ConcreteComponent
{
    public class Pasta : RestaurantDish
    {
        public Pasta(Dictionary<string, string> ingridents) 
            : base(nameof(Pasta), ingridents) 
        {
            
        }
    }
}