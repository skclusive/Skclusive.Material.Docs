using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Script;
using Skclusive.Script.DomHelpers;
using Skclusive.Script.Prisma;

namespace Skclusive.Material.Docs
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomHelpers();

            services.AddScriptHelpers();

            services.AddPrisma();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
