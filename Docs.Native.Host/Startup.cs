using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Docs.App.View;
using WebWindows.Blazor;
using Skclusive.Material.Layout;

namespace Skclusive.Material.Docs.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddDocsViewServices
            (
                new DocsViewConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .WithResponsive(false)
                .Build()
            );
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
