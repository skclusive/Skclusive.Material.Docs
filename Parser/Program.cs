using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MarkedNet;

namespace TestParser
{
    public class CustomRender : Renderer
    {
        public override string Code(string code, string lang, bool escaped)
        {
            var transformedCode = code;

            if (Options.Highlight != null)
            {
                var output = Options.Highlight(code, lang);
                if (output != null && output != code)
                {
                    escaped = true;
                    transformedCode = output;
                }
            }

            transformedCode = escaped ? transformedCode : StringHelper.Escape(transformedCode, true);
            var langClass = Options.LangPrefix + StringHelper.Escape(lang ?? string.Empty, true);

            return $"<pre{AttributesToString(this.Options.PreformattedTextAttributes)}><code class='{langClass}'>{transformedCode}\n</code></pre>\n";
        }

        public override string Blockquote(string quote)
        {
            return $"<blockquote>\n{quote}</blockquote>\n";
        }

        public override string Html(string html)
        {
            return html;
        }

        public override string Heading(string text, int level, string raw)
        {
            return $"<h{level} id='{Options.HeaderPrefix}{Regex.Replace(raw.ToLower(), @"[^\w]+", "-")}'>{text}</h{level}>\n";
        }

        public override string Hr()
        {
            return Options.XHtml ? "<hr/>\n" : "<hr>\n";
        }

        public override string List(string body, bool ordered)
        {
            var type = ordered ? "ol" : "ul";
            return $"<{type}>\n{body}</{type}>\n";
        }

        public override string ListItem(string text)
        {
            return $"<li>{text}</li>\n";
        }

        public override string Paragraph(string text)
        {
            return $"<p>{text}</p>\n";
        }

        public override string Table(string header, string body)
        {
            return $"<table{AttributesToString(this.Options.TableAttributes)}>\n<thead>\n{header}</thead>\n<tbody>\n{body}</tbody>\n</table>\n";
        }

        public override string TableRow(string content)
        {
            return $"<tr>\n{content}</tr>\n";
        }

        public override string TableCell(string content, TableCellFlags flags)
        {
            var type = flags.Header ? "th" : "td";
            var tag = !string.IsNullOrEmpty(flags.Align)
                ? $"<{type} style='text-align:{flags.Align}'>"
                : $"<{type}>";

            return tag + content + $"</{type}>\n";
        }

        public override string Strong(string text)
        {
            return $"<strong>{text}</strong>";
        }

        public override string Em(string text)
        {
            return $"<em>{text}</em>";
        }

        public override string Codespan(string text)
        {
            return $"<code>{text}</code>";
        }

        public override string Br()
        {
            return Options.XHtml ? "<br/>" : "<br>";
        }

        public override string Del(string text)
        {
            return $"<del>{text}</del>";
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

            var output = $"<a href='{href}'";

            if (!string.IsNullOrEmpty(title))
            {
                output += $" title='{title}'";
            }

            if (this.Options.ExternalLinks && (href.StartsWith("//") || href.StartsWith("http", StringComparison.InvariantCultureIgnoreCase)))
            {
                output += " target='_blank' rel='nofollow'";
            }

            output += $">{text}</a>";
            return output;
        }

        public override string Image(string href, string title, string text)
        {
            var output = $"<img src='{href}' alt='{text}'{AttributesToString(this.Options.ImageAttributes)}";

            if (!string.IsNullOrEmpty(title))
            {
                output += $" title='{title}'";
            }

            output += Options.XHtml ? "/>" : ">";
            return output;
        }

        public override string Text(string text)
        {
          return text;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var options = new Options();
            options.Renderer = new CustomRender();

            var text = @"---
title: Grid React component
components: Grid
---

> A flex **container** is the box generated by an element with a computed display of `flex` or `inline-flex`. In-flow children of a flex container are called flex **items** and are laid out using the flex layout model.

";

           var replaced = Regex.Replace(text, @"---[\r\n]([\s\S]*)[\r\n]---", "", RegexOptions.Multiline);

           var splits = Regex.Split(replaced, @"^{{(""demo"":[^}]*)}}$", RegexOptions.Multiline);

            foreach(var split in splits.Where(x => !Regex.IsMatch(x, @"^\s*$") && !Regex.IsMatch(x, @"^{{(""demo"":[^}]*)}}$")))
            {
                var tokens = Lexer.Lex(split, options);

                var parser = new Parser(options);

                var outx = parser.Parse(tokens);

                Console.WriteLine($"Parsed: {outx}");
            }
        }
    }
}
