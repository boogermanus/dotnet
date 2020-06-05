using FacadePattern.Models;

namespace FacadePattern.Subsystem
{
    public class DrinkPrepService : KitchenServiceBase
    {
        public DrinkPrepService() 
            : base(FoodItemCollection.DRINK_START, FoodItemCollection.DRINK_END)
        {
        }
    }
}