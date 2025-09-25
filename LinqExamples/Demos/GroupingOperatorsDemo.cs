using System;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class GroupingOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            Console.WriteLine("GroupBy");
            var byTeam = Heroes.GroupBy(h => h.Team);
            foreach (var team in byTeam)
            {
                Console.WriteLine(team.Key);
                team.Select(t => t.Name).ToList().ForEach(Console.WriteLine);
            }
        }
    }
}