using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using TicketShop.BlazorClient.Services;
using TicketShop.Shared.Entities;
using TicketShop.Shared.Utils;

namespace TicketShop.BlazorClient.Pages
{
    public partial class ShoppingCartPage
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [Inject] private IShoppingCartService ShoppingCartService { get; init; }

        private IEnumerable<Ticket> Tickets => ShoppingCartService.Tickets;

        private string TotalPrice
        {
            get { return PriceUtils.FormatEurCentsAsEur(Tickets.Sum(ticket => ticket.PriceInEurCents)); }
        }

        private void RemoveTicketFromShoppingCart(Ticket ticket)
        {
            ShoppingCartService.RemoveTicket(ticket);
        }
    }
}