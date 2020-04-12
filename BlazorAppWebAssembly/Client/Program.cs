using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorAppWebAssembly.Shared.Contracts;
using System.Net.Http;

namespace BlazorAppWebAssembly.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddBlazorContextMenu();
            //builder.Services.AddScoped<ICorderManager, CorderManager>();
            builder.Services.AddSingleton<ICorderManager, CorderManager>();

            //await builder.Build().RunAsync();
            var host = builder.Build();

            //var corderService = host.Services.GetRequiredService<CorderManager>();

            //corderService.http = host.Services.GetRequiredService<HttpClient>();

            await host.RunAsync();
        }
    }
}
