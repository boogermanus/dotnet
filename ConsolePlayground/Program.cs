using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace ConsolePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
      
            var studentGrades = new List<int>()
            { 88, 70, 69, 42, 90, 77, 83, 85, 89, 100 };

            studentGrades.Select((grade, index) => $"Student: {index} is: {grade}")
                .ToList()
                .ForEach(Console.WriteLine);
        }

    }
}
