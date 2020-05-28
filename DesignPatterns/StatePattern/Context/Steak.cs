using StatePattern.State;

namespace StatePattern.Context
{
    public class Steak
    {
        private Doneness _state;
        private string _beefCut;

        public Steak(string beefCut)
        {
            _beefCut = beefCut;
        }
    }
}