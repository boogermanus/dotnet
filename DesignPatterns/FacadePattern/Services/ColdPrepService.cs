using FacadePattern.Models;
namespace FacadePattern.Services
{
    public class ColdPrepService : KitchenServiceBase
    {
        public ColdPrepService() 
            : base(FoodItemCollection.APPETIZER_START, FoodItemCollection.APPETIZER_END )
        {

        }
    }
}