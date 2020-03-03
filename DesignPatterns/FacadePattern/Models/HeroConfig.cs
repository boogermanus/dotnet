using System;
using System.Linq;
namespace FacadePattern.Models
{
    public class HeroConfig
    {
        private const int MAX_COUNT = 3;
        public int FirstHeroId {get;set;}
        public int SecondHeroId {get;set;}
        public int ThirdHeroId {get;set;}

        public static HeroConfig GetConfig()
        {
            var validOptions =  Enumerable.Range(1, 6);
            var chosen = new int[MAX_COUNT];
            int count = 0;

            while(count < MAX_COUNT)
            {
                var optionsString = string.Join(',', validOptions.Where(vo => !chosen.Contains(vo)));
                Console.WriteLine($"Choose a Hero ID: {optionsString}");
                chosen[count++] = Convert.ToInt32(Console.ReadLine());
            }

            return new HeroConfig()
            {
                FirstHeroId = chosen[0],
                SecondHeroId = chosen[1],
                ThirdHeroId = chosen[2]
            };
        }
    }
}