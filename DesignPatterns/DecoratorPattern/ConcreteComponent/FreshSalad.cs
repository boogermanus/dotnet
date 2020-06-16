using System.Collections.Generic;
using DecoratorPattern.Component;

namespace DecoratorPattern.ConcreteComponent
{
    public class FreshSalad : RestaurantDish
    {
        public FreshSalad(Dictionary<string, string> ingridents) 
            : base("Fresh Salad", ingridents) 
        {
            
        }
    }
}