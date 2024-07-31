using System.Collections.Generic;

namespace Dnator.DnatorLib.interop.Excel.Manager
{
	public interface IManagerInteropExcel
    {
        /// <summary>
		/// Récupère l'adresse de la cellule  ex: 'A1','AA224' ...
		/// </summary>
		/// <param name="line"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		string GetCellAddress(int line, int column);
		
		/// <summary>
		/// Ecrit dans une cellule la valeur 
		/// 		
		/// </summary>
		/// <param name="line">ligne de la cellule</param>
		/// <param name="column">colonne de la cellule</param>
		/// <param name="value">valeur de la cellule</param>
		void WriteCell(int line, int column,string value);
		
		/// <summary>
		/// Ajoute une valeur à la donnée déja présente dans la cellule
		/// </summary>
		/// <param name="line">ligne de la cellule</param>
		/// <param name="column">colonne de la cellule</param>
		/// <param name="value">valeur de la cellule</param>
		void AddValCell(int line, int column,string value);
		
		/// <summary>
		/// renvoie la velur d'une cellule 
		/// </summary>
		/// <param name="line">ligne de la cellule</param>
		/// <param name="column">colonne de la cellule</param>
		/// <returns>retour de la valeur de la cellule</returns>
		string ReadCell(int line, int column);
	
		/// <summary>
		/// retourne une liste de valeur des cellules de la ligne 
		/// </summary>
		/// <param name="line">numéro de la ligne voulue</param>
		/// <returns>retour de la liste des cellules</returns>
		IList<string> ReadLine(int line);
			
		/// <summary>
		/// Retourne le numéro de ligne en fonction de la liste de valeur , contenant une ou plusieurs valeurs 
		/// Si il y a plsuieurs valmeur mettre le séparateur |
		/// Les valeurs doivent correspondre excatement au valeur contenu dans les cellules
		/// </summary>
		/// <param name="listValue">Liste des valeurs recherchée sur la ligne</param>
		/// <returns>Retourne le numéro de ligne</returns>
		int GetNumLine(IList<string> listValue);
		
		/// <summary>
		/// retourne les valeurs contenu dans la colonne en fonction du numéro de colonne 
		/// </summary>
		/// <param name="numColumn">numéro de colonne</param>
		/// <returns>retour liste des cellules</returns>
		IList<string> ReadColumn(int numColumn);

		/// <summary>
		/// retourne le numéro de colonne en fonction de la valeur du titre passé en paramètre
		/// </summary>
		/// <param name="titre">valeur du titre recherchée</param>
		/// <param name="titleLine"></param>
		/// <returns>numéro de colonne</returns>
		int GetColumnByTitre(string titre, int titleLine);
		
		/// <summary>
		/// Permet de créer un fichier si il existe ou de l'ouvrir si il existe déja
		/// avec le parma NomFichier
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
			
			
		/// <summary> 
        /// Selectionne un Range. 
        /// </summary> 
        /// <param name="ligneDebut">Ligne de la cellule Haut Gauche</param> 
        /// <param name="colonneDebut">Colonne de la cellule Haut Gauche</param> 
        /// <param name="ligneFin">Nombre de Lignes</param> 
        /// <param name="colonneFin">Nombres de Colonnes</param> 
        IList<IList<string>> GetSelectionRange(int ligneDebut, int colonneDebut, int ligneFin, int colonneFin);	
    }
}