using System;
using System.Collections.Generic;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Services
{
    public delegate void ShoppingCartChangedDelegate(object sender, EventArgs args);

    public interface IShoppingCartService
    {
        IEnumerable<Ticket> Tickets { get; }
        event ShoppingCartChangedDelegate ShoppingCartChanged;
        public void AddTicket(Ticket ticket);
        public int Count();
        void RemoveTicket(Ticket ticket);
    }
}