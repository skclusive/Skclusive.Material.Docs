using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Markdown.Component;
using Skclusive.Material.Layout;

namespace Skclusive.Material.Docs.App.View
{
    public static class DocsViewExtension
    {
        public static void TryAddDocsViewServices(this IServiceCollection services, IDocsViewConfig config)
        {
            services.AddScoped<IStyleTypeProvider, DocsViewStyleProvider>();

            services.TryAddMarkdownServices();

            services.TryAddLayoutServices(config);

            services.TryAddSingleton<IDocsViewConfig>(config);
        }
    }
}
