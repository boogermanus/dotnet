using System;
using PollyDemo.Demos;

namespace PollyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new RetryDemo().Demo();
        }
    }
}
