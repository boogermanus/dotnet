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
      
            var date = DateTime.UtcNow;
            Console.WriteLine(date);
            date = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);
            Console.WriteLine(date);
        }
    }
}
