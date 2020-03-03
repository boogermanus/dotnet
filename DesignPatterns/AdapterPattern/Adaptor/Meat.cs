using System;
using AdapterPattern.Target;
using AdapterPattern.Adaptee;
using AdapterPattern.Constants;
namespace AdapterPattern.Adaptor
{
    public class Meat : MeatBase
    {
        private MeatDatabase _meatDatabase = new MeatDatabase();
        
        public Meat(string name) : base(name) {}

        public override void LoadData()
        {
            SafeCookTempFahrenheit = _meatDatabase.GetSafeCookTemp(MeatName, TemperatureType.Fahrenheit);
            SafeCookTempCelsius = _meatDatabase.GetSafeCookTemp(MeatName, TemperatureType.Celsius);
            CaloriesPerOunce = _meatDatabase.GetCaloriesPerOunce(MeatName);
            ProteinPerOunce = _meatDatabase.GetProteinPerOunce(MeatName);

            Console.WriteLine($" Safe Cook Temp (F): {SafeCookTempFahrenheit}");
            Console.WriteLine($" Safe Cook Temp (C): {SafeCookTempCelsius}");
            Console.WriteLine($" Calories per Ounce: {CaloriesPerOunce}");
            Console.WriteLine($" Protein per Ounce: {ProteinPerOunce}");
        }
    }
}