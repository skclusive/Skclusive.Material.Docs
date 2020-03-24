using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using Skclusive.Core.Component;

namespace Skclusive.Material.Docs.App.View
{
    public class FrameComponent : MaterialComponent
    {
        public FrameComponent() : base("Frame")
        {
        }

        [Parameter]
        public IReference AbsoluteRef { get; set; } = new Reference();

        [Parameter]
        public string AbsoluteClass { set; get; }

        [Parameter]
        public string AbsoluteStyle { set; get; }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("height", "100%");

                yield return Tuple.Create<string, object>("width", "100%");

                yield return Tuple.Create<string, object>("position", "relative");
            }
        }

        protected virtual string _AbsoluteStyle
        {
            get => CssUtil.ToStyle(AbsoluteStyles, AbsoluteStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> AbsoluteStyles
        {
            get
            {
                yield return Tuple.Create<string, object>("position", "absolute");

                yield return Tuple.Create<string, object>("bottom", "0px");

                yield return Tuple.Create<string, object>("left", "0px");

                yield return Tuple.Create<string, object>("top", "0px");

                yield return Tuple.Create<string, object>("right", "auto");

                yield return Tuple.Create<string, object>("width", "100%");
            }
        }

        protected virtual string _AbsoluteClass
        {
            get => CssUtil.ToClass($"{Selector}-Absolute", AbsoluteClasses, AbsoluteClass);
        }

        protected virtual IEnumerable<string> AbsoluteClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
