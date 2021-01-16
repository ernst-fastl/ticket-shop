using System.Collections.Generic;
using System.Threading.Tasks;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTicketsForCityName(string cityName);
    }
}