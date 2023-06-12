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

        private static void JellyBeans()
        {
            // Build a collection of jelly beans
            var collection = new CandyCollection
            {
                [0] = new JellyBean("Cherry"),
                [1] = new JellyBean("Bubble Gum"),
                [2] = new JellyBean("Root Beer"),
                [3] = new JellyBean("French Vanilla"),
                [4] = new JellyBean("Licorice"),
                [5] = new JellyBean("Buttered Popcorn"),
                [6] = new JellyBean("Juicy Pear"),
                [7] = new JellyBean("Cinnamon"),
                [8] = new JellyBean("Coconut")
            };
            // Create iterator
            IJellyBeanIterator iterator = collection.CreateIterator();
            
            // give me current
            Console.WriteLine(iterator.CurrentBean);
            
            // give me at an index
            Console.WriteLine(collection[0]);
            
            // all
            Console.WriteLine("Gimme all the jelly beans!");
            for (JellyBean item = iterator.First();
            !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Flavor);
            }
            Console.ReadKey();
        }

        private static void Entities()
        {
            var collection = new EntityCollection();
            collection.Add(new Person("Lex Luthor"));
            collection.Add(new Hero("Batman"));
            collection.Add(new Hero("Superman"));
            collection.Add(new Hero("Flash"));
            collection.Add(new Person("Linda Park-West"));
            
            // give me count
            Console.WriteLine(collection.Count);
            
            // give me an index
            Console.WriteLine(collection[1]);

            Console.WriteLine("All the collection");
            
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
