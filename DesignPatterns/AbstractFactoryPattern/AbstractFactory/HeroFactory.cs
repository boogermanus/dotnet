namespace AbstractFactoryPattern
{
    public abstract class HeroFactory
    {
        public abstract Alias GetAlias();
        public abstract Name GetName();

        public override string ToString()
        {
            return $"I'm {GetName().GetName()}, but my alias is {GetAlias().GetAlias()}";
        }
    }
}