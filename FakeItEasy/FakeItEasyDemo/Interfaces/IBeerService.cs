using System.Collections.Generic;
using FakeItEasyDemo.Models;

namespace FakeItEasyDemo.Interfaces
{
    public interface IBeerService
    {
        IEnumerable<Beer> GetBeers();
        Beer GetBeer(int id);
    }
}