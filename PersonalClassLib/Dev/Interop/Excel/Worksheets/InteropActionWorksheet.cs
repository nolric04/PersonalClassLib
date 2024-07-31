using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using PersonalClassLib.Core;

namespace Dnator.DnatorLib.interop.Excel.Worksheets
{
    internal class InteropActionWorksheet:IInteropActionWorksheet
    {
        private static Workbook _workbook; 
        private static Worksheet _worksheet;
        public Workbook Workbook
        {
            get => _workbook;
            set => _workbook = value;
        }
        public Worksheet Worksheet
        {
            get => _worksheet;
            set => _worksheet = value;
        }
        /// <inheritdoc cref="IInteropActionWorksheet.ChangerDeWorksheetActive"/>
        public void ChangerDeWorksheetActive(string nomFeuille)
        {
            _worksheet = (Worksheet)_workbook.Sheets[nomFeuille];
            _worksheet.Activate();
        }
        /// <inheritdoc cref="IInteropActionWorksheet.AjouterWorksheet"/>
        public void AjouterWorksheet(string nomFeuille)
        {
            _workbook.Sheets.Add();
            _worksheet = (Worksheet)_workbook.Sheets[_workbook.Sheets.Count - 1];
            RenommerWorksheet(nomFeuille);
	        
            _worksheet.Activate();
        }
        /// <inheritdoc cref="IInteropActionWorksheet.RenommerWorksheet"/>
        public void RenommerWorksheet(string nomFeuille)
        {
            try
            {
                _worksheet.Name = nomFeuille;
            }
            catch (Exception e)
            {
                switch(e.Message) 
                {
                    case "Impossible de renommer une feuille comme une autre feuille, une bibliothèque d'objets référencée ou un classeur référencé par Visual Basic.":
                        CoreImpl.GetInstance().GetExceptionManager().ThrowError(4101,new Dictionary<string, string>()
                        {
                            {
                                "Non Feuille => ",nomFeuille
                            }
                        });
                        return;
                    default:
                        CoreImpl.GetInstance().GetExceptionManager().ThrowError(100,new Dictionary<string, string>
                        {
                            {
                                "Message => ",e.Message
                            }
                        });
                        break;
                }
            }
        }

        /// <inheritdoc cref="IInteropActionWorksheet.SupprimerWorksheet"/>
        public void SupprimerWorksheet()
        {
            _worksheet.Delete();
        }
    }
}