using System.Collections.Generic;

namespace FacadePattern.Models
{
    public class FoodItemCollection
    {
        private List<FoodItem> _foodItems = new List<FoodItem>();

        public List<FoodItem> FoodItems => _foodItems;

        public static readonly int APPETIZER_START = 0;
        public static readonly int APPETIZER_END = 3;
        public static readonly int ENTREE_START = 3;
        public static readonly int ENTREE_END = 6;
        public static readonly int DRINK_START = 6;
        public static readonly int DRINK_END = 9;

        public FoodItemCollection()
        {
            _foodItems.AddRange(AddAppetizers());
            _foodItems.AddRange(AddEntrees());
            _foodItems.AddRange(AddDrinks());

        }

        private List<FoodItem> AddAppetizers()
        {
            return new List<FoodItem>
            {
                new FoodItem
                {
                    DishId = 1,
                    ItemName = "Cheese Sticks"
                },
                new FoodItem
                {
                    DishId = 2,
                    ItemName = "Chips 'n Salsa"
                },
                                new FoodItem
                {
                    DishId = 3,
                    ItemName = "Hot Wings"
                },
            };
        }

        private List<FoodItem> AddEntrees()
        {
            return new List<FoodItem>
            {
                new FoodItem
                {
                    DishId = 4,
                    ItemName = "Hamburger & Fries"
                },
                new FoodItem
                {
                    DishId = 5,
                    ItemName = "Chicken Strips & Fries"
                },
                                new FoodItem
                {
                    DishId = 6,
                    ItemName = "Steak and Potato"
                },
            };
        }

        private List<FoodItem> AddDrinks()
        {
            return new List<FoodItem>
            {
                new FoodItem
                {
                    DishId = 7,
                    ItemName = "Coke"
                },
                new FoodItem
                {
                    DishId = 8,
                    ItemName = "Beer"
                },
                                new FoodItem
                {
                    DishId = 9,
                    ItemName = "Water"
                },
            };
        }
    }
}