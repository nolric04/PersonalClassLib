
using Dnator.DnatorLib.interop.Properties.Excel;
using PersonalClassLib.Dev.Interop.Properties.Excel;

namespace Dnator.DnatorLib.interop.Excel.Worksheets
{
    /// <summary>
    /// Ensemble de méthodes liées aux Worksheet
    /// </summary>
    internal interface IInteropActionWorksheet:IInteropExcelWorksheetProperty,IInteropExcelWorkbookProperty

    {
    /// <summary>
    /// Change la feuille active avec le nom de la feuille
    /// </summary>
    /// <param name="nomFeuille">Nom de la feuille à activer</param>
    void ChangerDeWorksheetActive(string nomFeuille);

    /// <summary>
    /// Ajoute une feuille de calcul dans le WorkBook
    /// </summary>
    /// <param name="nomFeuille">Nom donné à la Worksheet</param>
    void AjouterWorksheet(string nomFeuille);

    /// <summary>
    /// Renomme la Worksheet en cours
    /// </summary>
    /// <param name="nomFeuille">Nom donné à la Worksheet</param>
    void RenommerWorksheet(string nomFeuille);

    /// <summary>
    /// Supprime la WorkSheet en cours
    /// </summary>
    void SupprimerWorksheet();
    }
}