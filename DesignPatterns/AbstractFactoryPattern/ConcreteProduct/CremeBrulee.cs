using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.ConcreteProduct
{
    public class CremeBrulee : Dessert
    {
        public override string Name => nameof(CremeBrulee);
    }
}