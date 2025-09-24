using System.Linq;
using MoqItDemo.Interfaces;

namespace MoqItDemo.Services
{
    public class DependentService : IDependentService
    {
        private readonly IBeerService _beerService;

        public DependentService(IBeerService beerService)
        {
            _beerService = beerService;
        }

        public async Task<decimal> GetTotalAbv()
        {
            var beers = await _beerService.GetBeers();

            return beers?.Sum(b => b.Abv) ?? decimal.Zero;
        }

        public async Task<decimal> GetBeerAbv(int id)
        {
            var beer = await _beerService.GetBeer(id);

            return beer?.Abv ?? decimal.Zero;
        }
    }
}