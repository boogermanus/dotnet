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
            catch
            {
                Console.WriteLine("Final exception");
            }

        }
    }
}