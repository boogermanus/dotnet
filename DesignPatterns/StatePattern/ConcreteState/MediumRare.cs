using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class MediumRare : Doneness
    {
        public MediumRare(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            steak = state.Steak;
            lowerTemp = 140;
            upperTemp = 154.9999;
            CanEat = true;
        }

        public override void DonenessCheck()
        {
            if(currentTemp <= 0)
                steak.State = new Uncooked(this);

            if(currentTemp < lowerTemp)
                steak.State = new Rare(this);

            if(currentTemp > upperTemp)
                steak.State = new Medium(this);
        }
    }
}