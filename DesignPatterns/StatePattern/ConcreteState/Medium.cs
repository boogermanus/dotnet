using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Medium : Doneness
    {
        public Medium(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            steak = state.Steak;
            lowerTemp = 155;
            upperTemp = 169.9999;
            CanEat = true;
        }
        public override void DonenessCheck()
        {
            if(currentTemp <= 0)
                steak.State = new Uncooked(this);
            
            if(currentTemp < lowerTemp)
                steak.State = new MediumRare(this);

            if(currentTemp > upperTemp)
                steak.State = new WellDone(this);
        }
    }
}