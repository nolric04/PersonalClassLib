using PersonalClassLib.Core.Configuration;
using PersonalClassLib.Core.Reporting;
using PersonalClassLib.Core.Routage;

namespace PersonalClassLib.Core
{
    /// <summary>
    /// Coeur de La Librairie DNATOR
    /// </summary>
    public interface ICore
    {
        /// <summary>
        /// Agir sur l'interface ExceptionManager
        /// </summary>
        /// <returns></returns>
        IExceptionManager GetExceptionManager();
        /// <summary>
        /// Agir sur l'interface ILogManager
        /// </summary>
        /// <returns></returns>
        ILogManager GetLogManager();
        /// <summary>
        /// Agir sur l'interface IRouter
        /// </summary>
        /// <returns></returns>
        IRouter GetRouter();
        /// <summary>
        /// Agir sur l'interface IConfigurationProvider
        /// </summary>
        /// <returns></returns>
        IConfigurationProvider GetConfigurationProvider();
        /// <summary>
        /// Retourne le contexte de lancement 
        ///     -   Developpement
        ///     -   Production
        /// </summary>
        string G_CONTEXT_PROD { get; }

    }
}
