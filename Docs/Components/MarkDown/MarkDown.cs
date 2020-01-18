using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using MarkedNet;

namespace Skclusive.Material.Docs
{
    public class MarkDown : MaterialComponentBase
    {
        private MarkDownRenderer Renderer { get; }

        private Options Options { get; }

        private MarkDownParser Parser { get;  }

        private TokensResult TokensResult;

        public MarkDown() : base("MarkDown")
        {
            Options = new Options();

            Renderer = new MarkDownRenderer(3);

            Options.Renderer = Renderer;

            Parser = new MarkDownParser(Options);
        }

        [Parameter]
        public string Text { set; get; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            TokensResult = Lexer.Lex(Text, Options);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Section>(1);
            builder.AddAttribute(2, "ChildContent", (RenderFragment)((childBuilder) =>
            {
                Renderer.Builder = childBuilder;

                Parser.Parse(TokensResult);
            }));
            builder.CloseComponent();
        }
    }
}
