using System;
using System.Linq;
using System.Collections.Generic;
using FacadePattern.Interfaces;
using FacadePattern.Models;

namespace FacadePattern.Subsystem
{
    public abstract class KitchenServiceBase : IKitchenSection
    {
        public List<FoodItem> FoodItems {get;set;} = new List<FoodItem>();
        public KitchenServiceBase(int menuStart, int menuEnd)
        {
            FoodItems.AddRange(
                new FoodItemCollection()
                .FoodItems
                .Skip(menuStart)
                .Take(menuEnd - menuStart)
            );
        }
        public virtual FoodItem PrepDish(int dishId)
        {
            var foodItem = FoodItems.FirstOrDefault(i => i.DishId == dishId);
            if(foodItem == null)
                throw new InvalidOperationException($"{nameof(dishId)}: {dishId} not found in FoodItems");

            return foodItem;
        }
    }
}