using System.Net;
using MoqItDemo.Interfaces;
using MoqItDemo.Models;
using Newtonsoft.Json;

namespace MoqItDemo.Services
{
    public class BeerService : IBeerService
    {
        private string _baseUrl = "https://api.punkapi.com/v2/beers";
        
        public async Task<IEnumerable<Beer>?> GetBeers()
        {
            return await Get<Beer[]>();
        }

        public async Task<Beer?> GetBeer(int id)
        {
            var beers = await Get<Beer[]>($"/{id}");
            return beers.FirstOrDefault();
        }

        private async Task<T?> Get<T>(string? path = null)
        {
            var client = new HttpClient();
            
            var response = await client.GetAsync($"{_baseUrl}/{path}");

            return response.StatusCode != HttpStatusCode.OK
                ? throw new Exception("Error calling Punk API")
                : JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}