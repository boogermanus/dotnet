﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals
{
    public class EqualTests
    {
        internal static void Test()
        {
            var decimalNumber = 10m;
            var doubleNumber = 10d;
            var intNumber = 10;
            
            Console.WriteLine($"{decimalNumber == intNumber} {doubleNumber == intNumber}");
            Console.WriteLine($"{Equals(decimalNumber, intNumber)} {Equals(doubleNumber, intNumber)} {Equals(doubleNumber, decimalNumber)}");

            var c1 = new EqualClass("TestName");
            var c2 = new EqualClass("TestName");
            
            Console.WriteLine($"{c1 == c2} {Equals(c1, c2)} {c1.Name == c2.Name} {Equals(c1.Name, c2.Name)}");

        }

        internal static void TestHash()
        {
            var c1 = new EqualClass("TestName");
            var c2 = new EqualClass("TestName");

            var hashTable = new HashSet<EqualClass> { c1, c2 };
            Console.WriteLine($"{hashTable.Count}");

            var dictionary = new Dictionary<int, EqualClass>();
            dictionary[c1.GetHashCode()] = c1;
            dictionary[c2.GetHashCode()] = c2;
            //dictionary.Add(c2.GetHashCode(), c2);
            
            Console.WriteLine($"{dictionary.Count}");
        }

        class EqualClass
        {
            public EqualClass(string name)
            {
                Name = name;
            }
            public string Name { get; }

            public override bool Equals(object obj)
            {
                if (!(obj is EqualClass target))
                    return false;
            
                return Equals(Name, target.Name);
            }
            
            public override int GetHashCode()
            {
                return Name?.GetHashCode() ?? 0;
            }

        }
    }
}