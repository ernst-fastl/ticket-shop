using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TicketShop.BlazorClient.Services;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Shared
{
    public partial class NavMenu
    {
        private bool _collapseNavMenu = true;
        private string NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        [Inject] public ICityService CityService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _cities = await CityService.GetAllCities();
        }

        public IEnumerable<NavigationItem> NavigationItems
        {
            get
            {
                var items = new List<NavigationItem>();

                foreach (var city in _cities)
                {
                    var navigationItem = new NavigationItem();
                    navigationItem.Title = "Tickets " + city.Name;
                    navigationItem.Path = "ticketshop/" + city.Name;
                    items.Add(navigationItem);
                }

                return items;
            }
        }

        private IEnumerable<City> _cities = new List<City>();

        public class NavigationItem
        {
            public string Title { get; set; }
            public string Path { get; set; }
        }
    }
}