using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TicketShop.BlazorClient.Services;
using TicketShop.Shared.Entities;

namespace TicketShop.BlazorClient.Shared
{
    public partial class NavMenu
    {
        private IEnumerable<City> _cities = new List<City>();

        private bool _collapseNavMenu = true;
        private string NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        [Inject] private ICityService CityService { get; init; }
        [Inject] private IShoppingCartService ShoppingCartService { get; init; }

        private IEnumerable<NavigationItem> NavigationItems => CreateNavigationItemsForCities();

        private IEnumerable<NavigationItem> CreateNavigationItemsForCities()
        {
            return _cities.Select(city => new NavigationItem {Title = "Tickets " + city.Name, Path = "ticketshop/" + city.Name}).ToList();
        }

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            _cities = await CityService.GetAllCities();
            ShoppingCartService.ShoppingCartChanged += OnShoppingCartChanged;
        }

        private void OnShoppingCartChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }

        private class NavigationItem
        {
            public string Title { get; init; }
            public string Path { get; init; }
        }
    }
}