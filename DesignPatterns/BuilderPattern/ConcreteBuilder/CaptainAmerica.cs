using BuilderPattern.Builder;
using BuilderPattern.Product;

namespace BuilderPattern.ConcreteBuilder
{
    public class CaptainAmerica : AvengerBuilder
    {
        public CaptainAmerica() 
        {
            _avenger = new Avenger();
        }
        public override void SetAlias()
        {
            _avenger.Alias = "Steve Rodgers";
        }

        public override void SetName()
        {
            _avenger.Name = "Captain America";
        }

        public override void SetPowers()
        {
            _avenger.Powers = new string[] {"Vibranium Shield" , "Strength", "Endurance"};
        }
    }
}