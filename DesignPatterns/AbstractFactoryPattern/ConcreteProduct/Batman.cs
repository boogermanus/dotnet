using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.ConcreteProduct
{
    public class Batman : Alias
    {
        public override string GetAlias() => nameof(Batman);
    }
}