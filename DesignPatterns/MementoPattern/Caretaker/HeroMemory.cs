using MementoPattern.Memento;

namespace MementoPattern.Caretaker
{
    public class HeroMemory
    {
        public HeroMemento HeroMemento { get; set; }

        public HeroMemory(HeroMemento memento)
        {
            HeroMemento = memento;
        }
    }
}