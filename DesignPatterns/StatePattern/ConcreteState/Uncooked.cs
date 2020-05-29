using StatePattern.Context;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Uncooked : Doneness
    {
        public Uncooked(Steak meat)
        {
            steak = meat;
            currentTemp = 0;
            lowerTemp = 0;
            upperTemp = 130;
            canEat = false;
        }

        public Uncooked(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            Steak = state.Steak;
            lowerTemp = 0;
            upperTemp = 130;
            canEat = false;
        }

        public override void DonenessCheck()
        {
            if(currentTemp > upperTemp)
                Steak.State = new Rare(this);

        }


    }
}