using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Docs.App.View;
using WebWindows.Blazor;
using Skclusive.Material.Component;
using Skclusive.Markdown.Component;

namespace Skclusive.Material.Docs.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddMaterialServices();

            services.TryAddMarkdownServices();
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
