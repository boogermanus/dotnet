using System;
using System.Threading.Tasks;
using FakeItEasy;
using Polly;
using PollyDemo.Interfaces;

namespace PollyDemo.Demos
{
    public abstract class DemoBase
    {
        protected IWorker Worker { get; set; }

        protected DemoBase()
        {
            Worker = A.Fake<IWorker>();
        }

        protected void RetryHandler(Exception e, int count)
        {
            Console.WriteLine($"Attempt {count} - Exception: {e.Message}");
        }

        protected void RetryResultHandler(DelegateResult<int> result, int count)
        {
            Console.WriteLine($"Attempt {count} - Result: {result.Result}");
        }
        
    }
}