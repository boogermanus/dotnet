using System;
using System.IO;
using MediatorPattern.Mediators;
using MediatorPattern.Models;

namespace MediatorPattern.Colleagues
{
    public abstract class Hero
    {
        protected IHeroMediator _mediator;
        protected TextWriter _textWriter = Console.Out;
        public Hero(IHeroMediator mediator)
        {
            _mediator = mediator;
        }

        public void send(HeroMessage message)
        {
            foreach(var hero in message.Targets)
            {
                _textWriter.WriteLine($"{GetType().Name} sends to {hero.GetType().Name} message: {message.Message}");
                _mediator.SendMessage(this, message.Message, hero);
            }
        }

        public void notify(string message)
        {
            _textWriter.WriteLine($"{GetType().Name} receives message: {message}");
        }

        public virtual bool canNotify(Hero hero)
        {
            return true;
        }
    }
}