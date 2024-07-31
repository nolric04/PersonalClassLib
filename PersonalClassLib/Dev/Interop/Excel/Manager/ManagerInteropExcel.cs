using System.Collections.Generic;
using Dnator.DnatorLib.interop.Excel.Application;
using Dnator.DnatorLib.interop.Excel.Cells;
using Dnator.DnatorLib.interop.Excel.Manager;
using Dnator.DnatorLib.interop.Excel.Worksheets;
using PersonalClassLib.Dev.Interop.Excel.Application;

namespace PersonalClassLib.Dev.Interop.Excel.Manager
{
    /// <inheritdoc cref="IManagerInteropExcel"/>
    public class ManagerInteropExcel:IManagerInteropExcel
    {
        private IInteropActionCells _interopActionCells = new InteropActionCells();
        private IInteropActionWorksheet _interopActionWorksheet = new InteropActionWorksheet();
        private IMicrosoftInteropExcel _microsoftInteropExcel = new MicrosoftInteropExcel();
        

        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.GetCellAddress"/>
        /// </summary>
        public string GetCellAddress(int line, int column)
        {
            return _interopActionCells.GetCellAddress(line, column);
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.WriteCell"/>
        /// </summary>
        public void WriteCell(int line, int column, string value)
        {
            _interopActionCells.WriteCell(line, column, value);
            Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.AddValCell"/>
        /// </summary>
        public void AddValCell(int line, int column, string value)
        {
            value += _interopActionCells.ReadCell(line, column);
            _interopActionCells.WriteCell(line, column,value);
            Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.ReadCell"/>
        /// </summary>
        public string ReadCell(int line, int column)
        {
            return _interopActionCells.ReadCell(line, column);
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.ReadLine"/>
        /// </summary>
        public IList<string> ReadLine(int line)
        {
            return _interopActionCells.ReadLine(line);
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.GetNumLine"/>
        /// </summary>
        public int GetNumLine(IList<string> listValue)
        {
            return _interopActionCells.GetNumLine(listValue);
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.ReadColumn"/>
        /// </summary>
        public IList<string> ReadColumn(int numColumn)
        {
            return _interopActionCells.ReadColumn(numColumn);
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.GetColumnByTitre"/>
        /// </summary>
        public int GetColumnByTitre(string titre, int titleLine)
        {
            return _interopActionCells.GetColumnByTitre(titre, titleLine);
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.CreerOuOuvrirFichier"/>
        /// </summary>
        public void CreerOuOuvrirFichier(string nomFichier, bool afficherApplication)
        {
            _microsoftInteropExcel.CreerOuOuvrirFichier(nomFichier, afficherApplication);
            _interopActionWorksheet.Workbook = _microsoftInteropExcel.Workbook;
            _interopActionWorksheet.Worksheet = _microsoftInteropExcel.Worksheet;
            _interopActionCells.Worksheet = _interopActionWorksheet.Worksheet;
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.Enregistrer"/>
        /// </summary>
        public void Enregistrer()
        {
            _microsoftInteropExcel.Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.FermerWorkBook"/>
        /// </summary>
        public void FermerWorkBook()
        {
            _microsoftInteropExcel.FermerWorkBook();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.QuitterXl"/>
        /// </summary>
        public void QuitterXl()
        {
            _microsoftInteropExcel.QuitterXl();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.ChangerDeWorksheetActive"/>
        /// </summary>
        public void ChangerDeWorksheetActive(string nomFeuille)
        {
            _interopActionWorksheet.ChangerDeWorksheetActive(nomFeuille);
            _interopActionWorksheet.Workbook = _microsoftInteropExcel.Workbook;
            _microsoftInteropExcel.Worksheet = _interopActionWorksheet.Worksheet;
            _interopActionCells.Worksheet = _interopActionWorksheet.Worksheet;
            Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.AjouterWorksheet"/>
        /// </summary>
        public void AjouterWorksheet(string nomFeuille)
        {
            _interopActionWorksheet.AjouterWorksheet(nomFeuille);
            _microsoftInteropExcel.Worksheet = _interopActionWorksheet.Worksheet;            
            _interopActionCells.Worksheet = _interopActionWorksheet.Worksheet;
            Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.RenommerWorksheet"/>
        /// </summary>
        public void RenommerWorksheet(string nomFeuille)
        {
            _interopActionWorksheet.RenommerWorksheet(nomFeuille);
            _microsoftInteropExcel.Worksheet = _interopActionWorksheet.Worksheet;
            _interopActionCells.Worksheet = _interopActionWorksheet.Worksheet;
            Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.SupprimerWorksheet"/>
        /// </summary>
        public void SupprimerWorksheet()
        {
            _interopActionWorksheet.SupprimerWorksheet();
            _microsoftInteropExcel.Worksheet = _interopActionWorksheet.Worksheet;
            _microsoftInteropExcel.Workbook = _interopActionWorksheet.Workbook;
            _interopActionCells.Worksheet = _interopActionWorksheet.Worksheet;
            Enregistrer();
        }
        /// <summary>
        /// <inheritdoc cref="IManagerInteropExcel.GetSelectionRange"/>
        /// </summary>
        public IList<IList<string>> GetSelectionRange(int ligneDebut, int colonneDebut, int ligneFin, int colonneFin)
        {
            return _interopActionCells.SelectionRange(ligneDebut, colonneDebut, ligneFin, colonneFin);
        }
    }
}