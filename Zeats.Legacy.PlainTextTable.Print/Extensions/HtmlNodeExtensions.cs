using System;
using HtmlAgilityPack;
using Zeats.Legacy.PlainTextTable.HtmlParser.Extensions;
using Zeats.Legacy.PlainTextTable.HtmlParser.Renders;
using Zeats.Legacy.PlainTextTable.Print.Enums;

namespace Zeats.Legacy.PlainTextTable.Print.Extensions
{
    public static class HtmlNodeExtensions
    {
        public static bool Bold(this HtmlNode htmlNode, bool defaultValue)
        {
            return htmlNode.ContainsAttributes("bold") || defaultValue;
        }

        public static bool Italic(this HtmlNode htmlNode, bool defaultValue)
        {
            return htmlNode.ContainsAttributes("italic") || defaultValue;
        }

        public static bool Underline(this HtmlNode htmlNode, bool defaultValue)
        {
            return htmlNode.ContainsAttributes("underline") || defaultValue;
        }

        public static FontSize FontSize(this HtmlNode htmlNode, FontSize defaultValue)
        {
            if (!htmlNode.ContainsAttributes("font-size"))
                return defaultValue;

            var attribute = htmlNode.Attributes["font-size"];

            if (attribute == null || string.IsNullOrEmpty(attribute.Value))
                return defaultValue;

            if (attribute.Value.Equals("small", StringComparison.CurrentCultureIgnoreCase))
                return Enums.FontSize.Small;

            if (attribute.Value.Equals("normal", StringComparison.CurrentCultureIgnoreCase))
                return Enums.FontSize.Normal;

            if (attribute.Value.Equals("large", StringComparison.CurrentCultureIgnoreCase))
                return Enums.FontSize.Large;

            return defaultValue;
        }

        public static FontType FontType(this HtmlNode htmlNode)
        {
            return htmlNode.Name.Equals("bar-code", StringComparison.CurrentCultureIgnoreCase) ? Enums.FontType.BarCode : Enums.FontType.Text;
        }

        public static string Content(this HtmlNode htmlNode, int width)
        {
            var tag = htmlNode.Name.ToLower();

            switch (tag)
            {
                case "table":
                    return htmlNode.TableContent(width);

                case "p":
                    return htmlNode.ParagraphContent(width);

                case "br":
                    return htmlNode.BrContent(width);

                case "bar-code":
                    return htmlNode.BarCodeContent();

                case "hr":
                    return htmlNode.HrContent(width);

                default:
                    return string.Empty;
            }
        }

        private static string TableContent(this HtmlNode htmlNode, int width)
        {
            var render = new TableGridRender(htmlNode);

            return render.Render(width);
        }

        private static string ParagraphContent(this HtmlNode htmlNode, int width)
        {
            var render = new ParagraphGridRender(htmlNode);

            return render.Render(width);
        }

        private static string BrContent(this HtmlNode htmlNode, int width)
        {
            var render = new BrGridRender(htmlNode);

            return render.Render(width);
        }

        private static string BarCodeContent(this HtmlNode htmlNode)
        {
            return htmlNode.InnerText.Replace(Environment.NewLine, string.Empty);
        }

        private static string HrContent(this HtmlNode htmlNode, int width)
        {
            var render = new HrGridRender(htmlNode);

            return render.Render(width);
        }
    }
}