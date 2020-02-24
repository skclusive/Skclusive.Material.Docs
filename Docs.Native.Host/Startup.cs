using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Docs.App.View;
using WebWindows.Blazor;

namespace Skclusive.Material.Docs.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddDocsViewServices(new DocsViewConfigBuilder().WithResponsive(false).Build());
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
