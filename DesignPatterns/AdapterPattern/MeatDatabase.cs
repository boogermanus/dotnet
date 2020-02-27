using System;
using AdapterPattern.Constants;
namespace AdapterPattern
{
    // the Adaptee
    public class MeatDatabase
    {
        public static float GetSafeCookTemp(string meat, TemperatureType temperatureType)
        {
            switch (temperatureType)
            {
                case TemperatureType.Fahrenheit:
                    return GetFahrenheitTemps(meat);
                case TemperatureType.Celsius:
                    return GetFahrenheitTemps(meat);
                default:
                    throw new Exception("Unknown TemperatureType");
            }
        }

        private static float GetFahrenheitTemps(string meat)
        {
            switch (meat)
            {
                case MeatTypes.BEEF:
                case MeatTypes.PORK:
                    return 145.0f;
                case MeatTypes.CHICKEN:
                case MeatTypes.TURKEY:
                    return 165.0f;
                default:
                    return 165.0f;
            }
        }

        private static float GetCelsiusTemps(string meat)
        {
            switch (meat)
            {
                case MeatTypes.BEEF:
                case MeatTypes.VEAL:
                case MeatTypes.PORK:
                    return 63.0f;
                case MeatTypes.CHICKEN:
                case MeatTypes.TURKEY:
                    return 74.0f;
                default:
                    return 74.0f;
            }
        }

        public int GetCaloriesPerOunce(string meat)
        {
            switch (meat)
            {
                case MeatTypes.BEEF:
                    return 71;
                case MeatTypes.PORK:
                    return 69;
                case MeatTypes.CHICKEN:
                    return 66;
                case MeatTypes.TURKEY:
                    return 38; //Wow, turkey is lean!
                default:
                    return 0;
            }
        }

        public double GetProteinPerOunce(string meat)
        {
            switch (meat)
            {
                case MeatTypes.BEEF:
                    return 7.33f;
                case MeatTypes.PORK:
                    return 7.67f;
                case MeatTypes.CHICKEN:
                    return 8.57f;
                case MeatTypes.TURKEY:
                    return 8.5f;
                default:
                    return 0d;
            }
        }

    }
}