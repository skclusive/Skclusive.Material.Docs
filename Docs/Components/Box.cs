using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;

namespace Skclusive.Material.Docs
{
    public class Box : MaterialComponent
    {
        public Box() : base("Box")
        {
        }

        [Parameter]
        public int? Margin { set; get; }

        [Parameter]
        public string Display { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "style", _Style);
            builder.AddAttribute(2, "class", _Class);
            builder.AddContent(3, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                if (Margin.HasValue)
                {
                    yield return Tuple.Create<string, object>(nameof(Margin).ToLower(), $"calc(var(--theme-spacing, 8) * {Margin.Value}px)");
                }

                if (!string.IsNullOrWhiteSpace(Display))
                {
                    yield return Tuple.Create<string, object>(nameof(Display).ToLower(), Display.ToLower());
                }
            }
        }
    }
}
