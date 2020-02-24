namespace Skclusive.Material.Docs.App.View
{
    public interface IDocsViewConfig
    {
        bool Responsive { get; }
    }

    public class DocsViewConfigBuilder
    {
        private class DocsViewConfig : IDocsViewConfig
        {
            public bool Responsive { get; internal set; } = true;
        }

        private readonly DocsViewConfig config = new DocsViewConfig();

        public IDocsViewConfig Build()
        {
            return config;
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
    }
}
