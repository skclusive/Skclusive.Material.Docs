using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Material.Component;
using Skclusive.Markdown.Component;

namespace Skclusive.Material.Docs.App.View
{
    public static class DocsViewExtension
    {
        public static void TryAddDocsViewServices(this IServiceCollection services, IDocsViewConfig config)
        {
            services.TryAddMaterialServices();

            services.TryAddMarkdownServices();

            services.TryAddSingleton<IDocsViewConfig>(config);
        }
    }
}
