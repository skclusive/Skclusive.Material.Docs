using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Markdown.Component;
using Skclusive.Material.Layout;
using Skclusive.Material.Component;

namespace Skclusive.Material.Docs.App.View
{
    public static class DocsViewExtension
    {
        public static void TryAddDocsViewServices(this IServiceCollection services, IDocsViewConfig config)
        {
            services.TryAddMarkdownServices(config);

            services.TryAddLayoutServices(config);

            services.TryAddMaterialServices(config);

            services.TryAddScoped<IDocsViewConfig>(sp => config);

            services.TryAddStyleTypeProvider<DocsViewStyleProvider>();
        }
    }
}
