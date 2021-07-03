using System;
using System.Collections.Generic;
using HigherOrder.Models;

namespace HigherOrder.Interfaces
{
    public interface IHigherOrderProductRepository
    {
        public IEnumerable<Product> Get(Func<Product, bool> filter = null);
        public IEnumerable<Product> GetLinq(Func<Product, bool> filter = null);
    }
}