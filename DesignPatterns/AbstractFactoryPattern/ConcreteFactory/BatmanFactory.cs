namespace AbstractFactoryPattern
{
    public class BatmanFactory : HeroFactory
    {
        public override Alias GetAlias()
        {
            return new Batman();
        }

        public override Name GetName()
        {
            return new BruceWayne();
        }
    }
}