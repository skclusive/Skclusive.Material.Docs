using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Material.Component;
using Skclusive.Markdown.Component;
using Skclusive.Material.Layout;

namespace Skclusive.Material.Docs.App.View
{
    public static class DocsViewExtension
    {
        public static void TryAddDocsViewServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddMaterialServices();

            services.TryAddMarkdownServices();

            services.TryAddLayoutServices(config);
        }
    }
}
