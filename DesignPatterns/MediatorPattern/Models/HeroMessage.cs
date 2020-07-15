using System.Collections.Generic;
using MediatorPattern.Colleagues;

namespace MediatorPattern.Models
{
    public class HeroMessage
    {
        public List<Hero> Targets { get; private set; } = new List<Hero>();
        public string Message { get; private set; }

        public HeroMessage(string message, params Hero[] heroes)
        {
            Message = message;
            Targets.AddRange(heroes);
        }
    }
}