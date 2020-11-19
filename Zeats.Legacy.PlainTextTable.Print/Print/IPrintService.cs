using Zeats.Legacy.PlainTextTable.Print.Enums;

namespace Zeats.Legacy.PlainTextTable.Print.Print
{
    public interface IPrintService
    {
        void Print(PrintCollection printCollection);
        void Cut(string portName, CutType cutType = CutType.Full);
    }
}