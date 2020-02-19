using FacadePattern.Models;

namespace FacadePattern.Interfaces
{
    public interface KitchenSection
    {
        FoodItem PrepDish(int dishId);
    }
}