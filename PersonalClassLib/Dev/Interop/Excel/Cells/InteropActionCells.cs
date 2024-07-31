using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using PersonalClassLib.Core;

namespace Dnator.DnatorLib.interop.Excel.Cells
{
    internal class InteropActionCells:IInteropActionCells
    {
        private static Worksheet _worksheet; 
        private static Range _monRange;

        public Worksheet Worksheet
        {
            get => _worksheet;
            set => _worksheet = value;
        }

        /// <inheritdoc cref="IInteropActionCells.GetCellAddress"/>
        public string GetCellAddress(int line, int column)
        {
            var lettreAdresse = string.Empty;
            if (column < 0 )
                CoreImpl.GetInstance().GetExceptionManager().ThrowError(4103,new Dictionary<string, string>{{"Numéro de Colonne demandé",column.ToString()}});

            while (--column >= 0)
            {
                lettreAdresse = (char)('A' + column % 26 ) + lettreAdresse;
                column /= 26;
            }
            return lettreAdresse+line;
        }
        /// <inheritdoc cref="IInteropActionCells.WriteCell"/>
        public void WriteCell(int line, int column, string value)
        {
            _worksheet.Cells[line, column] = value;
        }
        /// <inheritdoc cref="IInteropActionCells.ReadCell"/>
        public string ReadCell(int line, int column)
        {
           return (_worksheet.Cells[line,column]as Range)?.Value2?.ToString();
        }
        /// <inheritdoc cref="IInteropActionCells.ReadLine"/>
        public IList<string> ReadLine(int line)
        {
            UpdateRange();
            var liCell = new List<string>();
            /*
             * _monrange peut commencer à une ligne différente de 1
             *	Il faut donc Ajouter le numéro de colonne de départ du Range au nombre de colonnes retenues dans le Range
             */
            for (var i = 1; i <  _monRange.Column + _monRange.Columns.Count; i++)
            {
                liCell.Add(ReadCell(line,i));
            }

            return liCell;
        }
        /// <inheritdoc cref="IInteropActionCells.GetNumLine"/>
        public int GetNumLine(IList<string> listValue)
        {
            UpdateRange();
            for (var i = 1; i <  _monRange.Row + _monRange.Rows.Count; i++)
            {
                if (!listValue.Except(ReadLine(i)).Any()) return i;
            }
            CoreImpl.GetInstance().GetExceptionManager().ThrowError(4102, new Dictionary<string, string>
            {
                {"Valeurs => ", listValue.Aggregate((i,j) => i+','+j) }
            });
	        
            return -1;
        }
        /// <inheritdoc cref="IInteropActionCells.ReadColumn"/>
        public IList<string> ReadColumn(int numColumn)
        {
            UpdateRange();
            var liCell = new List<string>();
            for (var i = 1; i <  _monRange.Row + _monRange.Rows.Count; i++)
            {
                liCell.Add(ReadCell(i,numColumn));
            }

            return liCell;
        }
        /// <inheritdoc cref="IInteropActionCells.GetColumnByTitre"/>
        public int GetColumnByTitre(string titre, int titleLine)
        {
            return ReadLine(titleLine).IndexOf(titre);
        }
        /// <inheritdoc cref="IInteropActionCells.SelectionRange"/>
        public IList<IList<string>> SelectionRange(int ligneDebut, int colonneDebut, int ligneFin, int colonneFin)
        {
            IList<IList<string>> tableau = new List<IList<string>>();

	        for (var i = ligneDebut; i < ligneFin+1; i++)
	        {
		        var liCell = new List<string>();
		        for (var j = colonneDebut; j < colonneFin+1; j++)
		        {
			        liCell.Add(ReadCell(i,j));
		        }
		        tableau.Add(liCell);
	        }

	        return tableau;
        }
        
                
        /// <summary>
        /// Met à jour la plage des données utilisées
        /// Attention : la sélection ne s'effectue que de la 1ere cellule écrite jusqu'à la dernière.
        ///				Les cellules présentes avant ne sont pas considérées. 
        /// </summary>
        private static void UpdateRange()
        {
            _monRange = _worksheet.UsedRange;
        }

    }
}