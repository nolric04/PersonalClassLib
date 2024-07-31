using System.Collections.Generic;

namespace PersonalClassLib.Core.Reporting
{
    /// <summary>
    /// Gestionnaire d'Exceptions de DNATOR
    /// </summary>
    public interface IExceptionManager
    {
        /// <summary>
        /// Permet de gérer un cas d'erreur selon les principes de la DNAT
        /// </summary>
        /// <param name="code"> Code Erreur disponible dans le fichier errors.xml</param>
        /// 
        void ThrowError(int code);

        /// <summary>
        /// Permet de gérer un cas d'erreur selon les principes de la DNAT
        /// </summary>
        /// <param name="code">Code Erreur disponible dans le fichier errors.xml</param>
        /// <param name="options">Liste des paramètres à renseigner dans le message d'erreur</param>
        void ThrowError(int code, IDictionary<string, string> options);

        /// <summary>
        /// Permet de gérer un cas d'Alerte selon les principes de la DNAT
        /// </summary>
        /// <param name="code"> Code Erreur disponible dans le fichier errors.xml</param>
        void ThrowWarn(int code);

        /// <summary>
        /// Permet de gérer un cas d'Alerte selon les principes de la DNAT
        /// </summary>
        /// <param name="code">Code Erreur disponible dans le fichier errors.xml</param>
        /// <param name="options">Liste des paramètres à renseigner dans le message d'erreur</param>
        void ThrowWarn(int code, IDictionary<string, string> options);
    }
}
