using System.Collections.Generic;
using HtmlAgilityPack;
using Zeats.Legacy.PlainTextTable.Print.Enums;

namespace Zeats.Legacy.PlainTextTable.Print.Print
{
    public class PrintCollection : List<PrintItem>
    {
        public readonly PrintOptions Options;

        public PrintCollection(PrintOptions options, string html, BarCodeType barCodeType)
        {
            Options = options;
            BarCodeType = barCodeType;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            foreach (var htmlNode in htmlDocument.DocumentNode.SelectNodes(".//table | .//p | .//br | .//bar-code | .//hr"))
                Add(htmlNode);
        }

        public BarCodeType BarCodeType { get; }

        private void Add(HtmlNode htmlNode)
        {
            var printItem = new PrintItem(Options, htmlNode, BarCodeType);

            Add(printItem);
        }
    }
}