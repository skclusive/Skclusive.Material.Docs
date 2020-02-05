using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;
using Skclusive.Material.Script;
using Skclusive.Script.Prism;

namespace Skclusive.Material.Docs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddDomHelpers();

            builder.Services.AddScriptHelpers();

            builder.Services.AddPrism();

            await builder.Build().RunAsync();
        }
    }
}
