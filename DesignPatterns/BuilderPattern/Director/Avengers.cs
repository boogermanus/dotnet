using BuilderPattern.Builder;

namespace BuilderPattern.Director
{
    public class Avengers
    {
        public void Assemble(AvengerBuilder builder)
        {
            builder.SetAlias();
            builder.SetName();
            builder.SetPowers();
        }
    }
}