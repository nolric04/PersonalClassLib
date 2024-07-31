using Microsoft.Office.Interop.Excel;

namespace Dnator.DnatorLib.interop.Properties.Excel
{
    internal interface IInteropExcelWorkbookProperty
    {
        Workbook Workbook { get; set; }
    }
}