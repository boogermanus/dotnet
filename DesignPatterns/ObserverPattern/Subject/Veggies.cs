using System.Collections.Generic;
using ObserverPattern.Observer;

namespace ObserverPattern.Subject
{
    public abstract class Veggies
    {
        private double _pricePerPound;
        public double pricePerPound
        {
            get => _pricePerPound;
            set
            {
                if(_pricePerPound != value)
                {
                    _pricePerPound = value;
                    Notify();
                }
            }
        }
        
        private List<IRestaurant> _restaurants;

        public Veggies(double pricePerPound)
        {
            _pricePerPound = pricePerPound;
        }

        public void Attach(IRestaurant restaurant)
        {
            _restaurants.Add(restaurant);
        }

        public void Detach(IRestaurant restaurant)
        {
            _restaurants.Remove(restaurant);
        }

        public void Notify()
        {
            foreach(var restaurant in _restaurants)
            {
                restaurant.Update(this);
            }
        }
    }
}