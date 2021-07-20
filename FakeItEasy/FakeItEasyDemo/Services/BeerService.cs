using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using FakeItEasyDemo.Models;
using Newtonsoft.Json;

namespace FakeItEasyDemo.Services
{
    public class BeerService : IBeerService
    {
        private string _baseUrl = "https://api.punkapi.com/v2/beers";
        
        public IEnumerable<Beer> GetBeers()
        {
            return GetResponse<Beer[]>(GetRequest());
        }

        public Beer GetBeer(int id)
        {
            var beers = GetResponse<Beer[]>(GetRequest(id.ToString()));
            return beers.FirstOrDefault();
        }

        private HttpWebRequest GetRequest(string path = null)
        {
            var request = WebRequest.CreateHttp($"{_baseUrl}/{path}");

            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";

            return request;
        }

        private T GetResponse<T>(HttpWebRequest request)
        {
            var response = (HttpWebResponse) request.GetResponse();

            using var reader = new StreamReader(response.GetResponseStream());
            
            var content = reader.ReadToEnd();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error calling Punk API");
            }

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}