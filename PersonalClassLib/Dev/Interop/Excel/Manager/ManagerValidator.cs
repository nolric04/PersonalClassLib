using Dnator.DnatorLib.interop.Excel.Application;
using Dnator.DnatorLib.interop.Excel.Worksheets;
using PersonalClassLib.Core;

namespace PersonalClassLib.Dev.Interop.Excel.Manager
{
    internal static class ManagerValidator
    {
        public static void VerifyApplicationExist(IMicrosoftInteropExcel microsoftInteropExcel)
        {
            if (microsoftInteropExcel.ApplicationExcel == null)
                CoreImpl.GetInstance().GetExceptionManager().ThrowError(4404);
        }
        public static void VerifyWorkbookOpen(IMicrosoftInteropExcel microsoftInteropExcel)
        {
            if (microsoftInteropExcel.Workbook==null)
                CoreImpl.GetInstance().GetExceptionManager().ThrowError(4405);
        }
        public static void VerifyWorksheetOpen(IMicrosoftInteropExcel microsoftInteropExcel)
        {
            if (microsoftInteropExcel.Worksheet==null)
                CoreImpl.GetInstance().GetExceptionManager().ThrowError(4406);
        }
        public static void VerifyWorksheetOpen(IInteropActionWorksheet interopWorksheet)
        {
            if (interopWorksheet.Worksheet==null)
                CoreImpl.GetInstance().GetExceptionManager().ThrowError(4406);
        }
    }
}