using System.Collections.Generic;
using MoqItDemo.Models;

namespace MoqItDemo.Interfaces
{
    public interface IBeerService
    {
        Task<IEnumerable<Beer>?> GetBeers();
        Task<Beer?> GetBeer(int id);
    }
}