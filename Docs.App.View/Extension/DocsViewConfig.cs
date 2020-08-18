using Skclusive.Material.Component;
using Skclusive.Material.Layout;

namespace Skclusive.Material.Docs.App.View
{
    public interface IDocsViewConfig : ILayoutConfig
    {
    }

    public class DocsViewConfigBuilder : LayoutConfigBuilder<DocsViewConfigBuilder, IDocsViewConfig>
    {
        protected class DocsViewConfig : LayoutConfig, IDocsViewConfig
        {
        }

        public DocsViewConfigBuilder() : base(new DocsViewConfig())
        {
        }

        protected override IDocsViewConfig Config()
        {
            return (IDocsViewConfig)_config;
        }

        protected override DocsViewConfigBuilder Builder()
        {
            return this;
        }
    }
}