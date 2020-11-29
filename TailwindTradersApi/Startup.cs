using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TailwindTradersApi;

[assembly: FunctionsStartup(typeof(Startup))]
namespace TailwindTradersApi
{
    
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<MyOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("MyOptions").Bind(settings);
                });
        }
    }
}
