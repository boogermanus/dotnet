using BuilderPattern.Product;

namespace BuilderPattern.Builder
{
    public abstract class AvengerBuilder
    {
        protected Avenger _avenger;
        public Avenger Avenger => _avenger;

        public abstract void SetName();
        public abstract void SetAlias();
        public abstract void SetPowers();
    }
}