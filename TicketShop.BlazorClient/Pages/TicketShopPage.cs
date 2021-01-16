using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TicketShop.BlazorClient.Services;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Pages
{
    public partial class TicketShopPage
    {
        // This type of injection doesn't work for server side Blazor
        // [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public ITicketService TicketService { get; set; }

        [Parameter] public string CityName { get; set; }

        private IEnumerable<Ticket> _tickets;
        protected override async Task OnParametersSetAsync()
        {
            _tickets = await TicketService.GetAllTicketsForCityName(CityName);
        }
    }
}