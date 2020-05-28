using BuilderPattern.Builder;
using BuilderPattern.Product;

namespace BuilderPattern.ConcreteBuilder
{
    public class BlackWidow : AvengerBuilder
    {
        public BlackWidow() 
        {
            _avenger = new Avenger();
        }
        public override void SetAlias()
        {
            _avenger.Alias = "Natalia Alianovna 'Natasha' Romanova";
        }

        public override void SetName()
        {
            _avenger.Name = "Black Widow";
        }

        public override void SetPowers()
        {
            _avenger.Powers = new string[] {"World-class Athlete", "Intellect", "Is Scarlett Johansson"};
        }
    }
}