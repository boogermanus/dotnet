using System;
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

        public void Assemble(AvengerBuilder[] builders)
        {
            foreach(var builder in builders)
            {
                Assemble(builder);
                Console.Write(builder.Avenger.ToString());
            }
        }
    }
}