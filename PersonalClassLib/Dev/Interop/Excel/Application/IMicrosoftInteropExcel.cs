/*
 * Created by Ranorex
 * User: BENCETTI-01323
 * Date: 03/06/2024
 * Time: 15:30
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */


using Dnator.DnatorLib.interop.Properties.Excel;
using PersonalClassLib.Dev.Interop.Properties.Excel;

namespace Dnator.DnatorLib.interop.Excel.Application
{
	/// <summary>
	/// Description of IInteropExcel.
	/// </summary>
	internal interface IMicrosoftInteropExcel:IInteropApplicationProperty,IInteropExcelWorkbookProperty,IInteropExcelWorksheetProperty
	{
		
		/// <summary>
		/// Permet de créer un fichier si il existe ou de l'ouvrir si il existe déja
		/// </summary>
		/// <param name="nomFichier">Nom du fichier à créer ou à ouvrir</param>
		/// <param name="afficherApplication">Ouvre le visuel de l'Application sur le poste</param>
		void CreerOuOuvrirFichier(string nomFichier, bool afficherApplication);
					
		/// <summary>
		/// Enregistre le fichier dans un chemin spésifique ou dans le chemin actuel 
		/// </summary>
		/// <param name="NomFichier">(Facultatif) Nom du fichier à enregitrer</param>
		void Enregistrer();
						
		/// <summary>
		/// Ferme le fichier ouvert
		/// </summary>
		void FermerWorkBook();
	
		/// <summary>
		/// Ferme l'application Excel
		/// </summary>
		void QuitterXl();
	}
}
