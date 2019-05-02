using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            Demo.TestIsPrime();
            Demo.TestDeferring();
            Demo.TestNonDeferring();
            // will throw in debugger
            TestTakeAndSkipOperator();
            TestTakeWhileAndSkipWhileOperators();
            TestSelectAndSelectMany();
            TestJoining();
            TestOrderBy();
            TestGroupBy();
            TestSets();
            TestConversions();
            TestElements();
            AdvancedStuff();
        }

        public static void TestTakeAndSkipOperator()
        {
            // a paging example with take and skip
            var collection = Enumerable.Range(1, 10000000);

            var hugeQuery = collection.Where(h => h % 2 == 0 && h % 7 == 0);

            var pageSize = 10;

            // remember, we don't actually execute the query until Count()
            for (int i = 0; i < hugeQuery.Count() / pageSize; i++)
            {
                // first time, skip 0 and take pageSize
                var pageQuery = hugeQuery
                    .Skip(i * pageSize)
                    .Take(pageSize);

                // print the pageSize
                foreach (var x in pageQuery)
                    Console.WriteLine(x);

                // only works with "console": "integratedTerminal" in launch.json
                // for debugger
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
        }

        public static void TestTakeWhileAndSkipWhileOperators()
        {
            int[] intArray = { 10, 4, 27, 53, 2, 96, 48 };

            // takes until condition is hit
            intArray
                .TakeWhile(i => i < 50)
                .ToList()
                .ForEach(i => Console.Write($"{i}\t"));

            Console.WriteLine();

            // skips until condition is hit
            intArray
                .SkipWhile(i => i < 50)
                .ToList()
                .ForEach(i => Console.Write($"{i}\t"));
            Console.WriteLine();
        }

        public static void TestSelectAndSelectMany()
        {
            var justiceLeague = Member.GetJusticeLeagueMembers();

            // select a List<string> for justice league members
            justiceLeague
                .Select(x => x.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x}"));

            // select a new list of tuples? 
            justiceLeague
                .Select(x => new { x.Name, x.Gender })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name}\t {x.Gender}"));

            // get the index in select
            justiceLeague.Select((m, i) => new { i, m.Name })
            .ToList()
            .ForEach(e => Console.WriteLine($"Index: {e.i} Name: {e.Name}"));

            var avengers = Member.GetAvengersMembers();

            // a list of both groups
            var teams = new List<List<Member>>
            {
                justiceLeague,
                avengers
            };

            // all female members
            teams
                .SelectMany(i => i.Where(x => x.Gender.Equals("Female")))
                .ToList()
                .ForEach(m => Console.WriteLine($"{m.Name}"));
        }

        public static void TestJoining()
        {
            var justiceLeague = Member.GetJusticeLeagueMembers();
            var avengers = Member.GetAvengersMembers();
            var powers = Member.GetPowers();

            // same sex match ups
            justiceLeague
                .Join(avengers, a => a.Gender, b => b.Gender,
                    (a, b) => $"{a.Name} + {b.Name}")
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            // name + power
            powers.
                Join(avengers, a => a, b => b.BestPower, (a, b)
                    => $"{b.Name} {a}")
                .ToList()
                .ForEach(s => Console.WriteLine(s));

            // groupJoin - power / names
            powers.
                GroupJoin(justiceLeague, power => power, member => member.BestPower,
                (power, members) => new { power = power, Members = members.Select(m => m) })
                .ToList()
                .ForEach(power =>
                {
                    Console.WriteLine(power.power);

                    foreach (var member in power.Members)
                    {
                        Console.WriteLine($"\t{member.Name}");
                    }
                });
            Console.WriteLine();
        }

        public static void TestOrderBy()
        {
            // order avengers by name
            Member.GetAvengersMembers()
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name}"));

            // order justice league members by name
            Member.GetJusticeLeagueMembers()
                .OrderBy(x => x, new HeroNameComparer())
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name}"));

            // order avengers members by year and then name - wasp/wasp2
            var members = Member.GetAvengersMembers();
            members.Add(new Member("Wasp 2", "Female", new DateTime(1981, 8, 22), "Flight"));
            members
                .OrderBy(x => x.MemberSince.Year)
                .ThenBy(x => x.Name)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name}"));
        }

        public static void TestGroupBy()
        {
            var members = new List<Member>();
            members.AddRange(Member.GetJusticeLeagueMembers());
            members.AddRange(Member.GetAvengersMembers());

            // groupby best power
            members
                .GroupBy(g => g.BestPower)
                .OrderBy(g => g.Key)
                .ToList()
                .ForEach(g =>
                {
                    Console.WriteLine(g.Key);
                    foreach (var member in g)
                        Console.WriteLine($"\t{member.Name}");

                    Console.WriteLine();
                });

        }

        public static void TestSets()
        {
            List<int> seq1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> seq2 = new List<int> { 3, 4, 5, 6, 7, 8 };

            // concat
            seq1.Concat(seq2).ToList()
                .ForEach(PrintToScreen);
            Console.WriteLine();
            // union
            seq1.Union(seq2).ToList()
                .ForEach(PrintToScreen);
            Console.WriteLine();
            // intersect
            seq1.Intersect(seq2).ToList()
                .ForEach(PrintToScreen);
            Console.WriteLine();
            // except
            seq1.Except(seq2).ToList()
                .ForEach(PrintToScreen);
            Console.WriteLine();
            seq2.Except(seq1).ToList()
                .ForEach(PrintToScreen);

            Console.WriteLine();
        }

        public static void TestConversions()
        {
            // book uses ArrayList, but this is not recommended
            List<object> arrayList = new List<object>();
            arrayList.AddRange(new List<object> { 1, 2, 3, 4, 5 });
            arrayList.AddRange(new string[] { "Bob", "John", "Amy", "Carl", "Kim" });

            // only print ints
            arrayList.OfType<int>().ToList()
                .ForEach(PrintToScreen);
            Console.WriteLine();

            // will fail because arrayList contains strings
            // arrayList.Cast<int>().ToList()
            //     .ForEach(PrintToScreen);

            // convert list of members to IMember and call Introduce
            Member.GetJusticeLeagueMembers()
                .Cast<IMember>()
                .ToList()
                .ForEach(m => m.Introduce());
        }

        public static void TestElements()
        {
            var members = Member.GetJusticeLeagueMembers();

            // old and busted
            var batman = members.Where(x => x.Name == "Batman").First();
            Console.WriteLine($"Found: {batman.Name}");
            // new hotness
            batman = members.First(x => x.Name == "Batman");
            Console.WriteLine($"Found: {batman.Name} ID: {batman.ID}");

            // will throw no memebers named robin
            // var robin = members.First(x => x.Name == "Robin");

            var newMembers = members;
            newMembers.Add(new Member("Batman", "Male", new DateTime(1990, 8, 12), "Nothing"));

            var secondBatman = newMembers.Last(x => x.Name == "Batman");

            Console.WriteLine($"Second {secondBatman.Name} ID: {secondBatman.ID}");

            // will not throw
            var robin = newMembers.LastOrDefault(x => x.Gender == "None");

            if (robin == null)
                Console.WriteLine("Can't find member with no gender");

            var oneAndOnly = members.Single(x => x.Name == "Superman");

            // will throw - can only find a single batman
            // oneAndOnly = newMembers.Single(x => x.Name == "Batman");

            // still not safe -- two bats
            // oneAndOnly = newMembers.SingleOrDefault(x => x.Name == "Batman");

            // safe
            oneAndOnly = members.SingleOrDefault(x => x.Name == "Robin");

            if (oneAndOnly == null)
                Console.WriteLine("Still can't find Robin");

            // safe
            var hero = members.ElementAt(2);
            Console.WriteLine($"My hero: {hero.Name}");

            // no!
            // hero = members.ElementAt(11);

            // safe
            hero = members.ElementAtOrDefault(11);
            Console.WriteLine($"My hero? {hero}");
        }

        public static void AdvancedStuff()
        {
            var members = Member.GetAvengersMembers();

            // create a dictionary based on name
            var membersDictionary = members.ToDictionary(m => m.Name);

            // show me thor's best power
            Console.WriteLine($"{membersDictionary["Thor"].BestPower}");

            // a lookup - can contain multiple keys
            members.Add(new Member("Wasp", "Female", new DateTime(2013, 5, 4), "Nothing"));

            // throws - can't do a dictionary anymore, no unique key
            // var badDictionary = members.ToDictionary(m => m.Name);

            // a lookup - it can have multiple keys
            var lookup = members.ToLookup(m => m.Name[0], m => $"{m.Name} {m.BestPower}");

            foreach (var group in lookup)
            {
                Console.WriteLine(group.Key);
                foreach (var member in group)
                    Console.WriteLine($"\t{member}");
            }

            // zip
            var ids = members.Select(m => m.ID);
            var names = members.Select(m => m.Name);

            // combine and 'zip' or merge
            ids.Zip(names, (id, name) => $"{id} {name}")
            .ToList()
            .ForEach(x => Console.WriteLine($"{x}"));

            // Aggregate
            var allMembers = members.Select(m => m.Name)
                .Aggregate((x, y) => $"{x} {y}");

            Console.WriteLine(allMembers);
        }

        private static Action<int> PrintToScreen = x => Console.Write($"..{x}");
    }
}
