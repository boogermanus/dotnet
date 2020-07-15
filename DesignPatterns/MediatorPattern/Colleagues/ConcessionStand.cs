using System;
using System.IO;
using MediatorPattern.Mediators;

namespace MediatorPattern.Colleagues
{
    public abstract class ConcessionStand
    {
        protected Mediator _mediator;
        protected TextWriter _textWriter = Console.Out;
        public ConcessionStand(Mediator mediator)
        {
            _mediator = mediator;
        }

        public void send(string message)
        {
            _textWriter.WriteLine($"{GetType().Name} sends message: {message}");
            _mediator.SendMessage(message, this);
        }

        public void notify(string message)
        {
            _textWriter.WriteLine($"{GetType().Name} received message: {message}");
        }
    }
}