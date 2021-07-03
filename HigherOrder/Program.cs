using System;
using System.Collections.Generic;
using System.Linq;
using HigherOrder.Mapper;
using HigherOrder.Services;

namespace HigherOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            DoListMapper();
            DoAdd();
            DoRepository();
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

        static void DoRepository() 
        {
            var repo = new HigherOrderProductRepository();

            var allProducts = repo.Get();
            allProducts.ToList().ForEach(Console.WriteLine);

            allProducts = repo.GetLinq();
            allProducts.ToList().ForEach(Console.WriteLine);

            var productsByCategoryId = repo.Get(p => p.CategoryId == 1);
            productsByCategoryId.ToList().ForEach(Console.WriteLine);

            productsByCategoryId = repo.GetLinq(p => p.CategoryId == 1);
            productsByCategoryId.ToList().ForEach(Console.WriteLine);

            var activeProducts = repo.Get(p => p.Active);
            activeProducts.ToList().ForEach(Console.WriteLine);

            var inactiveProducts = repo.GetLinq(p => !p.Active);
            inactiveProducts.ToList().ForEach(Console.WriteLine);
        }
    }
}
