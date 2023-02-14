using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Fundamentals
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var demos = new IDemo[]
            {
                new EnumerableTest(),
                new EqualTests(),
                new LambdaTest(),
                new StringConcatenation()
            };

            foreach (var demo in demos)
            {
                demo.Run();
            }
        }

    }
}