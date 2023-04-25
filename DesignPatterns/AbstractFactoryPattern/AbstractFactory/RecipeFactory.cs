using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.AbstractFactory
{
    public abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();
        public abstract Dessert CreateDessert();
    }
}