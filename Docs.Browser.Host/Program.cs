using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Docs.App.View;
using Skclusive.Material.Layout;

namespace Skclusive.Material.Docs.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<AppView>("app");

            builder.Services.AddBaseAddressHttpClient();

            builder.Services.TryAddDocsViewServices(new LayoutConfigBuilder().WithResponsive(true).Build());

            await builder.Build().RunAsync();
        }
    }
}
