using System;
using FakeItEasy;
using Polly;
using PollyDemo.Interfaces;

namespace PollyDemo.Demos
{
    public abstract class DemoBase
    {
        protected IWorker Worker { get; set; }

        public DemoBase()
        {
            Worker = A.Fake<IWorker>();
        }

        public void RetryHandler(Exception e, int count)
        {
            Console.WriteLine($"Attempt {count} - Exception: {e.Message}");
        }

        public void RetryResultHandler(DelegateResult<int> result, int count)
        {
            Console.WriteLine($"Attempt {count} - Result: {result.Result}");
        }
    }
}