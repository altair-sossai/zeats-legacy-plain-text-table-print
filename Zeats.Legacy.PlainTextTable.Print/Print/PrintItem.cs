using System;
using HtmlAgilityPack;
using Zeats.Legacy.PlainTextTable.Print.Enums;
using Zeats.Legacy.PlainTextTable.Print.Extensions;

namespace Zeats.Legacy.PlainTextTable.Print.Print
{
    public class PrintItem
    {
        private readonly PrintOptions _options;
        private string _content;

        public PrintItem(PrintOptions options, HtmlNode htmlNode)
        {
            _options = options;

            Bold = htmlNode.Bold(false);
            Italic = htmlNode.Italic(false);
            Underline = htmlNode.Underline(false);
            FontSize = htmlNode.FontSize(FontSize.Normal);
            FontType = htmlNode.FontType();
            Content = $"{htmlNode.Content(TableWidth)}{Environment.NewLine}";
        }

        public bool Bold { get; }
        public bool Italic { get; }
        public bool Underline { get; }
        public FontType FontType { get; }
        public FontSize FontSize { get; }

        public string Content
        {
            get => FontType == FontType.BarCode ? _content?.Replace(Environment.NewLine, string.Empty) : _content;
            private set => _content = value;
        }

        private int TableWidth => FontSize == FontSize.Small ? _options.TableWidthFontSizeSmall
            : FontSize == FontSize.Normal ? _options.TableWidthFontSizeNormal
            : FontSize == FontSize.Large ? _options.TableWidthFontSizeLarge
            : _options.TableWidthFontSizeNormal;
    }
}