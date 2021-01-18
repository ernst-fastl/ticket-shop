using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TicketShop.BlazorClient.Services;
using TicketShop.Shared.Entities;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace TicketShop.BlazorClient.Pages
{
    public partial class TicketShopPage
    {
        private IEnumerable<Ticket> _tickets;
        [Inject] private ITicketService TicketService { get; init; }
        [Inject] private IShoppingCartService ShoppingCartService { get; init; }
        [Parameter] public string CityName { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            _tickets = await TicketService.GetAllTicketsForCityName(CityName);
        }

        private void AddTicketToShoppingCart(Ticket ticket)
        {
            ShoppingCartService.AddTicket(ticket);
        }
    }
}