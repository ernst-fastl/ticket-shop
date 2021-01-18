using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TicketShop.BlazorClient.Services;

namespace TicketShop.BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Only works for client-side Blazor
            // builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            void HttpClientCreator(HttpClient client)
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            }

            builder.Services.AddHttpClient<ICityService, CityService>(HttpClientCreator);
            builder.Services.AddHttpClient<ITicketService, TicketService>(HttpClientCreator);
            builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();

            await builder.Build().RunAsync();
        }
    }
}