using System.Collections.Generic;

namespace PersonalClassLib.Core.Reporting
{
    /// <summary>
    /// Gestionnaire de logs
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Permet de récupérer le dernier Message généré
        /// </summary>
        string DernierMessage{ get; }
        /// <summary>
        /// Génère un log de réussite
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        void Success(int code);


        /// <summary>
        /// Génère un log de réussite
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        /// <param name="options">Options à indiquer dans le log</param>
        void Success(int code, IDictionary<string, string> options);


        /// <summary>
        /// Génère un log d'info
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        void Info(int code);


        /// <summary>
        /// Génère un log d'info
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        /// <param name="options">Options à indiquer dans le log</param>
        void Info(int code, IDictionary<string, string> options);
        
        /// <summary>
        /// Génère un log d'Warn
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        void Warn(int code);


        /// <summary>
        /// Génère un log d'Warn
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        /// <param name="options">Options à indiquer dans le log</param>
        void Warn(int code, IDictionary<string, string> options);
        
        /// <summary>
        /// Génère un log d'Error
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        void Error(int code);


        /// <summary>
        /// Génère un log d'Error
        /// </summary>
        /// <param name="code">Code du fichier de configuration</param>
        /// <param name="options">Options à indiquer dans le log</param>
        void Error(int code, IDictionary<string, string> options);

    }
}
