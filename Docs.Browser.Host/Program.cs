using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Blazor.Hosting;
using Skclusive.Material.Docs.App.View;

namespace Skclusive.Material.Docs.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<AppView>("app");

            builder.Services.TryAddDocsViewServices(new DocsViewConfigBuilder().Build());

            await builder.Build().RunAsync();
        }
    }
}
