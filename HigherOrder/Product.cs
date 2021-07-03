using System.Collections.Generic;

namespace HigherOrder.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Stem Bolt",
                    CategoryId = 1,
                    Active = true
                },
                new Product
                {
                    Name = "Widget",
                    CategoryId = 1,
                    Active = true,
                },
                new Product
                {
                    Name = "Kiwi",
                    CategoryId = 2,
                    Active = false
                }
            };
        }

        public override string ToString()
        {
            return $"{{{Name} - {CategoryId} - {Active}}}";
        }

    }
}