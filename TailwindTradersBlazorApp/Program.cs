using AntDesign.Pro.Layout;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TailwindTradersBlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["FunctionApiUrl"])
            };
            httpClient.DefaultRequestHeaders.Add("x-functions-key", builder.Configuration["FunctionKey"]);
            builder.Services.AddScoped(sp => httpClient);
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            await builder.Build().RunAsync();
        }
    }
}