using Skclusive.Core.Component;

namespace Skclusive.Material.Docs.App.View
{
    public class DocsViewStyleProvider : StyleTypeProvider
    {
        public DocsViewStyleProvider() : base(priority: default, typeof(AppStyle))
        {
        }
    }
}
