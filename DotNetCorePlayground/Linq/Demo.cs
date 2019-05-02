using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq {
    
    public class Demo 
    {
        
        public static void TestIsPrime()
        {
            int[] intArray =
             {
                0,  1,  2,  3,  4,  5,  6,  7,  8,  9,
                10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
                20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
                30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
                40, 41, 42, 43, 44, 45, 46, 47, 48, 49
            };
            
            Console.WriteLine("Prime Numbers fro 0 - 49 are:");
            intArray.Where(i => i.IsPrime())
            .ToList()
            .ForEach(i => Console.Write($"{i} \t"));
            Console.WriteLine();
        }

        public static void TestDeferring()
        {
            var members = Member.GetJusticeLeagueMembers();

            var memberQuery = members.Where(m => m.MemberSince.Year >= 1951);

            members.Add(new Member("Black Canary", "Female", new DateTime(1960, 8, 10), "Nothing"));

            memberQuery.ToList().ForEach(m => Console.WriteLine(m.Name));
        }

        
        public static void TestNonDeferring()
        {
            List<int> intList = new List<int>
           {
               0,  1,  2,  3,  4,  5,  6,  7,  8,  9
           };

            // build a query
            IEnumerable<int> queryInt =
                intList.Select(i => i * 2);

            //execute a query
            int queryIntCount = queryInt.Count();

            // cache a query - ToList makes it a real list
            List<int> queryIntCached =
                queryInt.ToList();

            // get the count
            int queryIntCachedCount =
                queryIntCached.Count();

            // clear the list
            intList.Clear();

            // we got this before the list was cleared so, it is valid
            Console.WriteLine($"Enumerate queryInt. Count {queryIntCount}.");

            // this doesn't have anything in it - no output
            foreach (int i in queryInt)
                Console.WriteLine(i);

            // same as the valid above
            Console.WriteLine($"Enumerate queryIntCached. Count {queryIntCachedCount}.");

            // this is a list and will print the elements, 
            // it was done before the list was clear
            foreach (int i in queryIntCached)
                Console.WriteLine(i);
        }
    }
    public static class ExtensionMethods
    {
        public static bool IsPrime(this int i)
        {
            if ((i % 2) == 0)
                return i == 2;
            int sqrt = (int)Math.Sqrt(i);

            for (var t = 3; t <= sqrt; t = t + 2)
            {
                if ((i % t) == 0)
                    return false;
            }

            return i != 1;
        }
    }

    public interface IMember
    {
        void Introduce();
    }

    public class Member : IMember
    {
        private static int _nextId = 1;
        public Member(string pName, string pGender, DateTime pMemberSince, string pPower)
        {
            ID = _nextId++;
            Name = pName;
            Gender = pGender;
            MemberSince = pMemberSince;
            BestPower = pPower;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime MemberSince { get; set; }

        public string BestPower { get; set; }

        public void Introduce() => Console.WriteLine($"I am {Name}, and my power is {BestPower}!");
        public static List<Member> GetJusticeLeagueMembers() => new List<Member>
        {
            new Member("Superman", "Male", new DateTime(1950, 1, 1), "Strength"),
            new Member("Wonder Women", "Female", new DateTime(1950, 1, 2), "Flight"),
            new Member("Batman", "Male", new DateTime(1950, 3, 3), "Mind"),
            new Member("Green Lantern", "Male", new DateTime(1951, 3, 5),"Mind"),
            new Member("Vixen", "Female", new DateTime(1990, 2, 4),"Nothing")
        };

        public static List<Member> GetAvengersMembers() => new List<Member>
        {
            new Member("Hulk", "Male", new DateTime(1965, 10, 4),"Strength"),
            new Member("Black Window", "Female", new DateTime(1970, 6, 28),"Mind"),
            new Member("Captain America", "Male", new DateTime(1941, 3, 5),"Mind"),
            new Member("Thor", "Male", new DateTime(1000, 2, 4),"Thunder"),
            new Member("Wasp", "Female", new DateTime(1976, 10, 23), "Flight")
        };

        public static List<string> GetPowers() => new List<string>
        {
            "Strength",
            "Flight",
            "Mind",
            "Nothing",
            "Thunder"
        };
    }

    public class HeroNameComparer : IComparer<Member>
    {
        public int Compare(Member x, Member y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}