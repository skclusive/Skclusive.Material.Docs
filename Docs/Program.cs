using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;
using Skclusive.Markdown.Component;

namespace Skclusive.Material.Docs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.TryAddMaterialServices();

            builder.Services.TryAddMarkdownServices();

            await builder.Build().RunAsync();
        }
    }
}
