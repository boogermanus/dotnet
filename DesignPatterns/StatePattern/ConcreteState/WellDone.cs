using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class WellDone : Doneness
    {
        public WellDone(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            steak = state.Steak;
            lowerTemp = 170;
            upperTemp = 230;
            CanEat = false;
        }
        public override void DonenessCheck()
        {
            if(currentTemp <= 0)
                steak.State = new Uncooked(this);
            
            if(currentTemp < lowerTemp)
                steak.State = new Medium(this);

            if(currentTemp > upperTemp)
                CanEat = false;
        }
    }
}