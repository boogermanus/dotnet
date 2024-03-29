﻿using System.Linq;
using FakeItEasyDemo.Interfaces;

namespace FakeItEasyDemo.Services
{
    public class DependentService : IDependentService
    {
        private readonly IBeerService _beerService;

        public DependentService(IBeerService beerService)
        {
            _beerService = beerService;
        }

        public decimal GetTotalAbv()
        {
            var beers = _beerService.GetBeers();

            return beers.Sum(b => b.Abv);
        }

        public decimal GetBeerAbv(int id)
        {
            var beer = _beerService.GetBeer(id);

            return beer?.Abv ?? decimal.Zero;
        }
    }
}