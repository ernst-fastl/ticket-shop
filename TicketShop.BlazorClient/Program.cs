using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            Action<HttpClient> baseHttpClientCreator = client => client.BaseAddress = baseAddress;
            builder.Services.AddHttpClient<ICityService, CityService>(baseHttpClientCreator);
            builder.Services.AddHttpClient<ITicketService, TicketService>(baseHttpClientCreator);

            await builder.Build().RunAsync();
        }
    }
}