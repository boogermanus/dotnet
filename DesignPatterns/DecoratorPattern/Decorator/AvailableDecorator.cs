using DecoratorPattern.Component;

namespace DecoratorPattern.Decarator
{
    public abstract class AvailableDecorator : RestaurantDish
    {
        protected RestaurantDish _dish;

        public AvailableDecorator(RestaurantDish dish)
        {
            _dish = dish;
        }
    }
}