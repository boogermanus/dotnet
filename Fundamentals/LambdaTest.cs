using System;
using System.Linq;

namespace Fundamentals
{
    public class LambdaTest : IDemo
    {
        private static void DoLambda()
        {
            var numbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Lambda
            numbers.Where(x => x > 1);

            // Func
            Func<int, bool> function = x => x > 1;
            numbers.Where(function);
            
            // method
            numbers.Where(Function);
            
            // no LINQ
            DoSomethingToEachThenPrintAll(numbers, index => numbers[index] += 1);
            
            
            // Lambda accessing outer variable
            var outerVariable = 3;
            DoSomethingToEachThenPrintAll(numbers, index => numbers[index] += outerVariable);
        }

        private static bool Function(int number)
        {
            return number > 1;
        }

        private static void DoSomethingToEachThenPrintAll(int[] numbers, Action<int> doSomethingForEach)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                //doSomethingForEach?.Invoke(i);
                doSomethingForEach(i);
            }
            
            Console.WriteLine(string.Join(", ", numbers));
        }

        public void Run()
        {
            DoLambda();
        }
    }
}