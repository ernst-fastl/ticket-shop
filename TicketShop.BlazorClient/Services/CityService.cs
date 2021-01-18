using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Services
{
    public class CityService : ICityService
    {
        private readonly HttpClient _httpClient;

        public CityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<City>>
            (await _httpClient.GetStreamAsync("api/cities.json"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }
    }
}