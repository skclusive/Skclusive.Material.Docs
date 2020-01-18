using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System;

namespace Skclusive.Material.Docs
{
    public class Dynamic : MaterialComponentBase
    {
        [Parameter]
        public Type Type { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(1, Type);
            builder.CloseComponent();
        }
    }
}
