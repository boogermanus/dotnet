using System;
using System.Collections.Generic;
using System.Text;
using DecoratorPattern.Component;

namespace DecoratorPattern.Decarator
{
    public class AvailableDecorator : RestaurantDish
    {
        protected RestaurantDish _dish;
        private List<string> _customers = new List<string>();
        private int _numberAvailable = 0;

        public AvailableDecorator(RestaurantDish dish, int available)
            : this(dish)
        {
            _numberAvailable = available;
        }

        public AvailableDecorator(RestaurantDish dish)
        {
            _dish = dish;
        }

        public void OrderItem(string name)
        {
            if(_numberAvailable > 0)
            {
                _customers.Add(name);
                _numberAvailable--;
            }
            else
            {
                Console.WriteLine($"Not enough available for {name}'s order!");
            }
        }

        public override string ToString() 
        {
            var builder = new StringBuilder();

            builder.AppendLine(_dish.ToString());

            foreach(var customer in _customers)
            {
                builder.AppendLine($"Ordered by {customer}");
            }

            return builder.ToString();
        }
    }
}