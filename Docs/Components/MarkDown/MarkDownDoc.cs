using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Skclusive.Material.Docs
{
    public class MarkDownDoc : MaterialComponentBase
    {
        [Parameter]
        public string Text { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var replaced = Regex.Replace(Text, @"---[\r\n]([\s\S]*)[\r\n]---", "", RegexOptions.Multiline);

            var splits = Regex.Split(replaced, @"^{{(""demo"":[^}]*)}}$", RegexOptions.Multiline);

            int index = 0;
            foreach(var split in splits.Where(x => !Regex.IsMatch(x, @"^\s*$")))
            {
                builder.OpenRegion(index++);

                if (split.StartsWith(@"""demo"":"))
                {
                    var start = @"""demo"": """.Length;
                    var type = Type.GetType(split.Substring(start, split.Length - start - 1));
                    builder.OpenComponent<Demo>(1);
                    builder.AddAttribute(2, "Type", type);
                    builder.CloseComponent();
                } else
                {
                    builder.OpenComponent<MarkDown>(1);
                    builder.AddAttribute(2, "Text", split);
                    builder.CloseComponent();
                }
                builder.CloseRegion();
            }
        }
    }
}
