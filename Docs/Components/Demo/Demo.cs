using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Docs
{
    public class DemoComponent : MaterialComponentBase
    {
        public DemoComponent() : base("Demo")
        {
        }

        [Parameter]
        public Type Type { set; get; }

        [Parameter]
        public string LinkStyle { set; get; }

        [Parameter]
        public string LinkClass { set; get; }

        protected virtual string _LinkStyle
        {
            get => CssUtil.ToStyle(LinkStyles, LinkStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> LinkStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _LinkClass
        {
            get => CssUtil.ToClass($"{Selector}-Link", LinkClasses, LinkClass);
        }

        protected virtual IEnumerable<string> LinkClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
