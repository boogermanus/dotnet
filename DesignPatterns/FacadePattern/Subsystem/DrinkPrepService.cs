using FacadePattern.Models;

namespace FacadePattern.Services
{
    public class DrinkPrepService : KitchenServiceBase
    {
        public DrinkPrepService() 
            : base(FoodItemCollection.DRINK_START, FoodItemCollection.DRINK_END)
        {
        }
    }
}