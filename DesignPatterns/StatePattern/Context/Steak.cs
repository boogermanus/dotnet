using System;
using System.Text;
using StatePattern.ConcreteState;
using StatePattern.State;

namespace StatePattern.Context
{
    public class Steak
    {

        private string _beefCut;

        public Steak(string beefCut)
        {
            _beefCut = beefCut;
            State = new Uncooked(this);
        }

        public Doneness State { get; set; }

        public void AddTemp(double amount)
        {
            State.AddTemp(amount);
            var status = new StringBuilder()
                .AppendLine($"Increased temperature by {amount} degrees")
                .AppendLine($"Current Temp is {State.CurrentTemp}")
                .AppendLine($"Status is {State.GetType().Name}")
                .ToString();
            Console.WriteLine(status);
        }

        public void RemoveTemp(double amount)
        {
            State.RemoveTemp(amount);
            var status = new StringBuilder()
                .AppendLine($"Decreased temperature by {amount} degrees")
                .AppendLine($"Current Temp is {State.CurrentTemp}")
                .AppendLine($"Status is {State.GetType().Name}")
                .ToString();
            Console.WriteLine(status);
        }
    }
}