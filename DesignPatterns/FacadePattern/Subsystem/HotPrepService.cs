using FacadePattern.Models;

namespace FacadePattern.Services
{
    public class HotPrepService : KitchenServiceBase
    {
        public HotPrepService() 
            : base(FoodItemCollection.ENTREE_START, FoodItemCollection.ENTREE_END)
        {
        }
    }
}