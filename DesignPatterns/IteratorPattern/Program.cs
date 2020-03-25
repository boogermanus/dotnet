using System;
using IteratorPattern.Models;
using IteratorPattern.Iterators;
using IteratorPattern.ConcreteAggregates;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            JellyBeans();
            Console.WriteLine();
            Entities();
        }

        static void JellyBeans()
        {
            // Build a collection of jelly beans
            CandyCollection collection = new CandyCollection();
            collection[0] = new JellyBean("Cherry");
            collection[1] = new JellyBean("Bubble Gum");
            collection[2] = new JellyBean("Root Beer");
            collection[3] = new JellyBean("French Vanilla");
            collection[4] = new JellyBean("Licorice");
            collection[5] = new JellyBean("Buttered Popcorn");
            collection[6] = new JellyBean("Juicy Pear");
            collection[7] = new JellyBean("Cinnamon");
            collection[8] = new JellyBean("Coconut");
            // Create iterator
            IJellyBeanIterator iterator = collection.CreateIterator();
            Console.WriteLine("Gimme all the jelly beans!");
            for (JellyBean item = iterator.First();
            !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Flavor);
            }
            Console.ReadKey();
        }

        static void Entities()
        {
            EntityCollection collection = new EntityCollection();
            collection.Add(new Person("Lex Luthor"));
            collection.Add(new Hero("Batman"));
            collection.Add(new Hero("Superman"));
            collection.Add(new Hero("Flash"));
            collection.Add(new Person("Linda Park-West"));

            IEntityIterator iterator = collection.CreateIterator();
            var entity = iterator.First();
            while(!iterator.IsDone)
            {
                Console.WriteLine(entity.Name);
                entity = iterator.Next();
            }
        }
    }
}
