using System.Collections.Generic;
using HigherOrder.Models;

namespace HigherOrder.Interfaces
{
    public interface IProductRepository
    {
        int Create(Product product);
        bool Update(Product product);
        bool Delete(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetActive();
        // etc...
    }
}