using FacadePattern.Models;

namespace FacadePattern.Interfaces
{
    public interface IKitchenSection
    {
        FoodItem PrepDish(int dishId);
    }
}