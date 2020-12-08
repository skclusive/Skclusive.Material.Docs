using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Docs.App.View
{
    public class DocsViewStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var isDark = theme.IsDark();

            return new Dictionary<string, string>
            {
                ["--theme-docs-palette-border-color"] = (isDark ? "rgba(255, 255, 255, 0.12)" : "rgba(0, 0, 0, 0.12)"),
            };
        }
    }
}