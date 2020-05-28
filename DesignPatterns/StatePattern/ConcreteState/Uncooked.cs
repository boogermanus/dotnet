using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Uncooked : Doneness
    {
        public Uncooked(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            steak = state.Steak;
            lowerTemp = 0;
            upperTemp = 130;
            canEat = false;
        }

        public override void DonenessCheck()
        {
            if(currentTemp > upperTemp)
                steak.State = new Rare(this);

        }


    }
}