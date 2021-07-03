using System;
using System.Collections.Generic;
using HigherOrder.Mapper;
namespace HigherOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            DoListMapper();
            DoAdd();
        }

        static void DoListMapper()
        {
            var myList = new List<int> {1,2,3,4,5};

            int multiplyBy2(int num) => num *2;
            var multipledList = ListMapper.Map(myList, multiplyBy2);
            var output = string.Join(", ", multipledList);
            Console.WriteLine(output);

            bool isEven(int num) => num % 2 == 0;
            var isEvenList = ListMapper.Map(myList, isEven);
            output = string.Join(", ", isEvenList);
            Console.WriteLine(output);
        }

        static void DoAdd()
        {
            Func<int, int> Add(int a) => (int b) => a + b;

            var add9 = Add(9);

            var sum1 = add9(1);
            Console.WriteLine(sum1);

            var sum2 = add9(2);
            Console.WriteLine(sum2);
        }
    }
}
