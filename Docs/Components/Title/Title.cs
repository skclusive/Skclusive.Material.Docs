using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Docs
{
    public class TitleComponent : MaterialComponentBase
    {
        public TitleComponent() : base("Title")
        {
        }

        [Parameter]
        public string Text { set; get; }

        [Parameter]
        public int Level { set; get; } = 1;

        protected string Component => $"h{Level}";

        [Parameter]
        public string AnchorStyle { set; get; }

        [Parameter]
        public string AnchorClass { set; get; }

        [Parameter]
        public string AnchorLinkStyle { set; get; }

        [Parameter]
        public string AnchorLinkClass { set; get; }

        protected virtual string _AnchorStyle
        {
            get => CssUtil.ToStyle(AnchorStyles, AnchorStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> AnchorStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _AnchorClass
        {
            get => CssUtil.ToClass($"{Selector}-Anchor", AnchorClasses, AnchorClass);
        }

        protected virtual IEnumerable<string> AnchorClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected virtual string _AnchorLinkStyle
        {
            get => CssUtil.ToStyle(AnchorLinkStyles, AnchorLinkStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> AnchorLinkStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _AnchorLinkClass
        {
            get => CssUtil.ToClass($"{Selector}-Anchor-Link", AnchorLinkClasses, AnchorLinkClass);
        }

        protected virtual IEnumerable<string> AnchorLinkClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
