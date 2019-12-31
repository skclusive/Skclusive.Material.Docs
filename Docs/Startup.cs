using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Script;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Docs
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomHelpers();

            services.AddScriptHelpers();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
