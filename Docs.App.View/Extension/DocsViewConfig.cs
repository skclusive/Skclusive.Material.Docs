using Skclusive.Material.Component;

namespace Skclusive.Material.Docs.App.View
{
    public interface IDocsViewConfig : IMaterialConfig
    {
        bool Responsive { get; }
    }

    public class DocsViewConfigBuilder : MaterialConfigBuilder<DocsViewConfigBuilder, IDocsViewConfig>
    {
        private class DocsViewConfig : MaterialConfig, IDocsViewConfig
        {
            public bool Responsive { get; internal set; } = true;
        }

        private readonly DocsViewConfig config;

        public DocsViewConfigBuilder() : this(new DocsViewConfig())
        {
        }

        private DocsViewConfigBuilder(DocsViewConfig config) : base(config)
        {
            this.config = config;
        }

        public DocsViewConfigBuilder WithResponsive(bool responsive)
        {
            config.Responsive = responsive;

            return this;
        }

        public DocsViewConfigBuilder With(IDocsViewConfig config)
        {
            WithResponsive(config.Responsive);

            return this;
        }

        protected override DocsViewConfigBuilder Builder()
        {
            return this;
        }

        protected override IDocsViewConfig Config()
        {
            return (IDocsViewConfig)_config;
        }
    }
}
