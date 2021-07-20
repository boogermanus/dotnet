using System.Collections.Generic;
using FakeItEasy.Models;

namespace FakeItEasy
{
    public interface IBeerService
    {
        IEnumerable<Beer> GetBeers();
        Beer GetBeer(int id);
    }
}