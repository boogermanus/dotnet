using System;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class JoiningOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            Console.WriteLine("GroupJoin");
            // don't know when you'd ever use this...
            var groupJoin = Classifications.GroupJoin(Sidekicks, std => std.Id, s => s.ClassificationId,
                (std, sidekickGroup) => new
                {
                    Sidekicks = sidekickGroup,
                    Name = std.ClassificationName
                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.Name);
                item.Sidekicks.ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("Join - Bomb");
            // join is the bomb
            var heroes = Heroes.Join(Sidekicks, h => h.Name, hs => hs.Partner, (h, hs) => h);
            heroes.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Join - Bomb discard");
            // discard the parameter
            var moreHeroes = Heroes.Join(Sidekicks, h => h.Name, hs => hs.Partner, (h, _) => h);
            moreHeroes.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Join - Still Bomb");
            // still being the bomb
            var teams = Heroes.Join(Sidekicks, h => h.Name, hs => hs.Partner, (h, hs) => new
            {
                Hero = h.Name,
                Sidekick = hs.Name
            }).ToList();

            foreach (var team in teams)
            {
                Console.WriteLine($"Team - {team.Hero}/{team.Sidekick}");
            }
        }
    }
}