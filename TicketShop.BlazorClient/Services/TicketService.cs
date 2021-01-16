using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;

        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Ticket>> GetAllTicketsForCityName(string cityName)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Ticket>>
                (await _httpClient.GetStreamAsync($"api/tickets/{cityName}.json"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}