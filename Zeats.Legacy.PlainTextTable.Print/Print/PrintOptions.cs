namespace Zeats.Legacy.PlainTextTable.Print.Print
{
    public class PrintOptions
    {
        public PrintOptions(string portName, int tableWidthFontSizeSmall, int tableWidthFontSizeNormal, int tableWidthFontSizeLarge)
        {
            PortName = portName;
            TableWidthFontSizeSmall = tableWidthFontSizeSmall;
            TableWidthFontSizeNormal = tableWidthFontSizeNormal;
            TableWidthFontSizeLarge = tableWidthFontSizeLarge;
        }

        public string PortName { get; }
        public int TableWidthFontSizeSmall { get; }
        public int TableWidthFontSizeNormal { get; }
        public int TableWidthFontSizeLarge { get; }
    }
}