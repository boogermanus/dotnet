using StatePattern.Context;

namespace StatePattern.State
{
    public abstract class Doneness
    {
        protected Steak steak;
        protected double currentTemp;
        protected double lowerTemp;
        protected double upperTemp;
        protected bool canEat;

        public Steak Steak
        {
            get => steak;
            set => steak = value;
        }

        public double CurrentTemp
        {
            get => currentTemp;
            set => currentTemp = value;
        }

    }
}