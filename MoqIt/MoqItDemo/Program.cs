// See https://aka.ms/new-console-template for more information

using MoqItDemo.Services;

var service = new BeerService();

var beers = await service.GetBeers();

beers?.ToList().ForEach(Console.WriteLine);

var beer = service.GetBeer(26);
Console.WriteLine(beer);
