using System.ComponentModel;

namespace Zeats.Legacy.PlainTextTable.Print.Enums
{
    public enum BarCodeType
    {
        [Description("EAN 13")]
        Ean13 = 0,

        [Description("CODE 128")]
        Code128 = 1
    }
}