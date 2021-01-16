using System.Collections.Generic;
using System.Threading.Tasks;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
    }
}