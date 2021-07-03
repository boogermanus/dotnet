using System;
using System.Collections.Generic;
using System.Linq;
using HigherOrder.Interfaces;
using HigherOrder.Models;

namespace HigherOrder.Services
{
    public class HigherOrderProductRepository : IHigherOrderProductRepository
    {
        private readonly List<Product> _products = Product.GetProducts();
        public IEnumerable<Product> Get(Func<Product, bool> filter = null)
        {
            if (filter == null)
                return _products;

            var filterList = new List<Product>();

            _products.ForEach(p => {
                if(filter(p))
                    filterList.Add(p);
            });

            return filterList;
        }

        public IEnumerable<Product> GetLinq(Func<Product, bool> filter = null)
        {
            if(filter == null)
                return _products;

            return _products.Where(filter);
        }
    }
}