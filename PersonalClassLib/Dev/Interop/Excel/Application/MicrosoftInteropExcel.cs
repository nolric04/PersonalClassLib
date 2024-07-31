/*
 * Created by Ranorex
 * User: BENCETTI-01323
 * Date: 03/06/2024
 * Time: 15:28
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dnator.DnatorLib.interop.Excel.Application;
using Dnator.DnatorLib.interop.Properties.Excel;
using Microsoft.Office.Interop.Excel;
using PersonalClassLib.Core;
using PersonalClassLib.Dev.Interop.Properties.Excel;
using PersonalClassLib.Dev.PathMethods;

namespace PersonalClassLib.Dev.Interop.Excel.Application
{
	/// <summary>
	/// Description of InteropExcel.
	/// </summary>
	internal class MicrosoftInteropExcel : IMicrosoftInteropExcel,IInteropExcelWorkbookProperty,IInteropExcelWorksheetProperty,IInteropApplicationProperty
	{
		#region Attributs

		private static Microsoft.Office.Interop.Excel.Application _applicationExcel;
		private static Workbooks _lesWorkBooks;
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

		public Microsoft.Office.Interop.Excel.Application ApplicationExcel
		{
			get => _applicationExcel;
		}

		#endregion

		public MicrosoftInteropExcel()
		{
			Init();
		}

		/// <summary>
        /// Initialise l'association à l'application excel ainsi qu'aux workbooks associés
        /// </summary>
        private static void Init()
        {
	        if (_applicationExcel != null) return;
	        
	        _applicationExcel = new Microsoft.Office.Interop.Excel.Application(); 
	        _lesWorkBooks = _applicationExcel.Workbooks;
        }
		
        /// <inheritdoc cref="IMicrosoftInteropExcel.CreerOuOuvrirFichier"/>>
		public void CreerOuOuvrirFichier(string nomFichier, bool afficherApplication)
		{
			if (string.IsNullOrEmpty(nomFichier))
			{
				CoreImpl.GetInstance().GetExceptionManager().ThrowError(4402,new Dictionary<string, string>
				{
					{
						"NomFichier manquant",nomFichier
					}
				});
				return;
			};
			
			try
			{
				//Détection du chemin relatif
				if (CoreImpl.GetInstance().GetRouter().GetDomain<IRelativePath>().IsCheminRelatif(nomFichier))
				{
					nomFichier = CoreImpl.GetInstance().GetRouter().GetDomain<IRelativePath>().ConvertAbsolutePath(nomFichier);
				}

				// Permet de Découper le Path 
				var pathSplitted = nomFichier.Split('\\').ToList();
				
				//Créé les Dossiers s'ils n'existent pas
				pathSplitted.RemoveAt(pathSplitted.Count - 1);
				Directory.CreateDirectory(pathSplitted.Aggregate((k,v)=>k+'\\'+v));
				
				if (!File.Exists(nomFichier))
				{
					//Créé un nouveau workbook vide
					_workbook = _lesWorkBooks.Add();
					
					//Message de log
					CoreImpl.GetInstance().GetLogManager().Info(2051, new Dictionary<string, string>
					{
						{"Chemin", nomFichier}
					});
					_workbook.SaveAs(nomFichier);
				}
				
				_workbook = _lesWorkBooks.Open(nomFichier);
				_worksheet = (Worksheet)_workbook.Sheets.Item[1];
				
				
				//Active la page choisie 
				_worksheet.Activate();
				_applicationExcel.Visible = afficherApplication;
			} 
			catch (Exception e) 
			{ 
				CoreImpl.GetInstance().GetExceptionManager().ThrowError(100,new Dictionary<string, string>
				{
					{
						"Valeur :",e.Message
					},
					{
						"Stacktrace", e.StackTrace
					}
				}); 
			} 
		}



        /// <inheritdoc cref="IMicrosoftInteropExcel.Enregistrer"/>>
        public void Enregistrer()
        {
	        _workbook.Save();
        }
		
        /// <inheritdoc cref="IMicrosoftInteropExcel.FermerWorkBook"/>>
        public void FermerWorkBook()
        {
	        _workbook.Close(true);
        }
		
        /// <inheritdoc cref="IMicrosoftInteropExcel.QuitterXl"/>>
        public void QuitterXl()
        {
	        _applicationExcel.Workbooks.Close();
	        _applicationExcel.Quit();
        }
	}
}
