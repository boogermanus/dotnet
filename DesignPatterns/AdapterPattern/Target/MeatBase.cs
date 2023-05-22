using System;
namespace AdapterPattern.Target
{
    public class MeatBase
    {
        protected string MeatName;
        protected float SafeCookTempFahrenheit;
        protected float SafeCookTempCelsius;
        protected double CaloriesPerOunce;
        protected double ProteinPerOunce;
        private const string PADDING = " ----- ";

        public MeatBase(string meat)
        {
            MeatName = meat;
        }

        public virtual void LoadData()
        {
            Console.WriteLine($"Meat: {MeatName}{PADDING}");
        }
    }
}