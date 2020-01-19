using System;
using System.Text.RegularExpressions;
using MarkedNet;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Script.Prism;

namespace Skclusive.Material.Docs
{
    public class MarkDownRenderer : Renderer
    {
        public RenderTreeBuilder Builder { get; set; }

        public bool QuoteInProgress { get; set; }

        public bool ListInProgress { get; set; }

        private int Index { get; set; }

        public MarkDownRenderer(int index)
        {
            Index = index;
        }

        public override string Code(string code, string lang, bool escaped)
        {
            Builder.OpenComponent<PrismCode>(Index++);
            Builder.AddAttribute(Index++, "Language", lang);
            Builder.AddAttribute(Index++, "Code", code);
            Builder.CloseComponent();

            return string.Empty;
        }

        public override string Blockquote(string quote)
        {
            var markup = $"<blockquote>\n{quote}</blockquote>\n";

            Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Html(string html)
        {
            var markup = html;

            Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Heading(string text, int level, string raw)
        {
            Builder.OpenComponent<Title>(Index++);
            Builder.AddAttribute(Index++, "Level", level);
            Builder.AddAttribute(Index++, "Text", text);
            Builder.CloseComponent();

            return string.Empty;
        }

        public override string Hr()
        {
            var markup = Options.XHtml ? "<hr/>\n" : "<hr>\n";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string List(string body, bool ordered)
        {
            var type = ordered ? "ol" : "ul";
            var markup = $"<{type}>\n{body}</{type}>\n";

            Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string ListItem(string text)
        {
            var markup = $"<li>{text}</li>\n";

            //Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Paragraph(string text)
        {
            var markup = $"<p>{text}</p>\n";

            if (!QuoteInProgress && !ListInProgress)
            {
                Builder.AddMarkupContent(Index++, markup);
            }

            return markup;
        }

        public override string Table(string header, string body)
        {
            var markup = $"<table{AttributesToString(this.Options.TableAttributes)}>\n<thead>\n{header}</thead>\n<tbody>\n{body}</tbody>\n</table>\n";

            Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string TableRow(string content)
        {
            var markup = $"<tr>\n{content}</tr>\n";

            //Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string TableCell(string content, TableCellFlags flags)
        {
            var type = flags.Header ? "th" : "td";
            var tag = !string.IsNullOrEmpty(flags.Align)
                ? $"<{type} style='text-align:{flags.Align}'>"
                : $"<{type}>";

            var markup = tag + content + $"</{type}>\n";

            //Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Strong(string text)
        {
            var markup = $"<strong>{text}</strong>";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Em(string text)
        {
            var markup = $"<em>{text}</em>";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Codespan(string text)
        {
            var markup = $"<code>{text}</code>";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Br()
        {
            var markup = Options.XHtml ? "<br/>" : "<br>";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Del(string text)
        {
            var markup = $"<del>{text}</del>";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Link(string href, string title, string text)
        {
            if (Options.Sanitize)
            {
                string prot = null;

                try
                {
                    prot = Regex.Replace(StringHelper.DecodeURIComponent(StringHelper.Unescape(href)), @"[^\w:]", String.Empty).ToLower();
                }
                catch (Exception)
                {
                    return string.Empty;
                }

                if (prot.IndexOf("javascript:") == 0 || prot.IndexOf("vbscript:") == 0)
                {
                    return string.Empty;
                }
            }

            var markup = $"<a href='{href}'";

            if (!string.IsNullOrEmpty(title))
            {
                markup += $" title='{title}'";
            }

            if (this.Options.ExternalLinks && (href.StartsWith("//") || href.StartsWith("http", StringComparison.InvariantCultureIgnoreCase)))
            {
                markup += " target='_blank' rel='nofollow'";
            }

            markup += $">{text}</a>";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Image(string href, string title, string text)
        {
            var markup = $"<img src='{href}' alt='{text}'{AttributesToString(this.Options.ImageAttributes)}";

            if (!string.IsNullOrEmpty(title))
            {
                markup += $" title='{title}'";
            }

            markup += Options.XHtml ? "/>" : ">";

            // Builder.AddMarkupContent(Index++, markup);

            return markup;
        }

        public override string Text(string text)
        {
            // Builder.AddMarkupContent(Count++, text);

            return text;
        }
    }
}
