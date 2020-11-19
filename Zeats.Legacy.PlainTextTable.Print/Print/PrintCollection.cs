using System.Collections.Generic;
using HtmlAgilityPack;

namespace Zeats.Legacy.PlainTextTable.Print.Print
{
    public class PrintCollection : List<PrintItem>
    {
        public readonly PrintOptions Options;

        public PrintCollection(PrintOptions options, string html)
        {
            Options = options;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            foreach (var htmlNode in htmlDocument.DocumentNode.SelectNodes(".//table | .//p | .//br | .//bar-code | .//hr"))
                Add(htmlNode);
        }

        private void Add(HtmlNode htmlNode)
        {
            Add(new PrintItem(Options, htmlNode));
        }
    }
}