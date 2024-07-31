using System;
using System.Collections.Generic;

namespace PersonalClassLib.Core.Configuration
{
    /// <summary>
    /// Gestionnaire des parametres des fichiers de config
    /// </summary>
    public  interface IConfigurationProvider
    {
        string ValueProduction { get; }
        string ValueDeveloppement { get; }
        /// <summary>
        /// Retourne un dictionnaire des domaines de Dnator par une paire 'Interface'-'Implémentation'.
        /// Le fichier est défini par la clé "FileConfig_DomainActive" via la méthode GetEnvironment().
        /// </summary>
        IDictionary<Type, Type> GetActiveDomains{ get; }
        /// <summary>
        /// Retourne un dictionnaire des messages d'erreurs de Dnator par une paire 'Code numérique'-'Message'.
        /// Le fichier est défini par la clé "FileConfig_Errors" via la méthode GetEnvironment().
        /// </summary>
        IDictionary<int, string> GetErrorMessages{ get; }
    }
}
