using System;
using FakeItEasy;
using Polly;
using PollyDemo.Interfaces;

namespace PollyDemo.Demos
{
    public class RetryDemo : DemoBase, IDemo
    {
        public void Demo()
        {

            A.CallTo(() => Worker.DoWork()).Throws(() => new Exception("No work from me"));

            // retry once
            try
            {
                var retryPolicy = Policy.Handle<Exception>()
                    .Retry(RetryHandler);
                retryPolicy.Execute(Worker.DoWork);
            }
            catch(Exception e)
            {
                Console.WriteLine($"One try and we're done {e.Message}");
            }
            
            // retry three times
            try
            {
                var retryThreeTimes = Policy.Handle<Exception>()
                    .Retry(3, RetryHandler);
                retryThreeTimes.Execute(Worker.DoWork);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Three tries and we're done {e.Message}");
            }

        }
    }
}