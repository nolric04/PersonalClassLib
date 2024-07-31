using Microsoft.Office.Interop.Excel;

namespace PersonalClassLib.Dev.Interop.Properties.Excel
{
    internal interface IInteropExcelWorksheetProperty
    {
        Worksheet Worksheet { get; set; }
    }
}