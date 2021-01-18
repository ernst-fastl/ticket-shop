using System;
using System.Collections.Generic;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<Ticket> _tickets = new();
        public event ShoppingCartChangedDelegate ShoppingCartChanged;

        public IEnumerable<Ticket> Tickets => _tickets;

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
            ShoppingCartChanged?.Invoke(this, new EventArgs());
        }

        public int Count()
        {
            return _tickets.Count;
        }

        public void RemoveTicket(Ticket ticket)
        {
            _tickets.Remove(ticket);
            ShoppingCartChanged?.Invoke(this, new EventArgs());
        }
    }
}