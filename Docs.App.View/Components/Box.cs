﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;

namespace Skclusive.Material.Docs.App.View
{
    public class Box : MaterialComponent
    {
        public Box() : base("Box")
        {
        }

        [Parameter]
        public int? Margin { set; get; }

        [Parameter]
        public int? Padding { set; get; }

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
                    yield return Tuple.Create<string, object>(nameof(Margin).ToLower(), $"calc(var(--theme-spacing) * {Margin.Value}px)");
                }

                if (Padding.HasValue)
                {
                    yield return Tuple.Create<string, object>(nameof(Padding).ToLower(), $"calc(var(--theme-spacing) * {Padding.Value}px)");
                }

                if (!string.IsNullOrWhiteSpace(Display))
                {
                    yield return Tuple.Create<string, object>(nameof(Display).ToLower(), Display.ToLower());
                }
            }
        }
    }
}
