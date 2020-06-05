using FacadePattern.Models;

namespace FacadePattern.Subsystem
{
    public class HotPrepService : KitchenServiceBase
    {
        public HotPrepService() 
            : base(FoodItemCollection.ENTREE_START, FoodItemCollection.ENTREE_END)
        {
        }
    }
}