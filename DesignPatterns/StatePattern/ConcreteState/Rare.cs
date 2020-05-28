using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Rare : Doneness
    {
        public Rare(Doneness state)
        {
            currentTemp = state.CurrentTemp;
            steak = state.Steak;
            lowerTemp = 130;
            upperTemp = 139.9999;
            canEat = true;
        }

        public override void DonenessCheck()
        {
            if(currentTemp < lowerTemp)
                steak.State = new Uncooked(this);
            
            if(currentTemp > upperTemp)
                ;//steak.State = new MediumRare();
            
        }
    }
}