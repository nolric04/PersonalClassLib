using System;
using PersonalClassLib.Core.Configuration;
using PersonalClassLib.Core.Reporting;
using PersonalClassLib.Core.Routage;

namespace PersonalClassLib.Core
{

    public class CoreImpl : ICore
    {
        #region constantes
        /// <summary>
        /// test
        /// </summary>
        public static string TYPE_AUTOMATE_DEVELOPPEMENT;
        public static string TYPE_AUTOMATE_PRODUCTION;
        public static string CONTEXT_AUTOMATE_DEVELOPPEMENT;
        public static string CONTEXT_AUTOMATE_PRODUCTION;
        #endregion
        #region Parametrage
        private static ICore _instance = null;
        private static IRouter _router;
        private static IExceptionManager _exceptionManager;
        private static ILogManager _logManager;
        private static IConfigurationProvider _configurationProvider;

        public IExceptionManager GetExceptionManager() => _exceptionManager;
        /// <inheritdoc/>
        public ILogManager GetLogManager() => _logManager;
        /// <inheritdoc/>
        public IRouter GetRouter() => _router;
        /// <inheritdoc/>
        public IConfigurationProvider GetConfigurationProvider() => _configurationProvider;

        /// <inheritdoc/>
        public string G_CONTEXT_PROD
        {
            get
            {
                if (CONTEXT_AUTOMATE_PRODUCTION == _configurationProvider.ValueProduction)return TYPE_AUTOMATE_PRODUCTION;
                if (CONTEXT_AUTOMATE_DEVELOPPEMENT == _configurationProvider.ValueDeveloppement)return TYPE_AUTOMATE_DEVELOPPEMENT;
                GetExceptionManager().ThrowError(110);
                throw new Exception();
            }
        }
        #endregion

        #region Instanciation
        /// <summary>
        /// Instanciation primaire des  attributs
        /// </summary>
        private CoreImpl()
        {
            //singleton mis en place
            _instance = this;
        }

        private static void InitInstanciation()
        {
            //Instanciations Initiale des parametres
            _router = new Router();
            _logManager = new LogManager();
            _exceptionManager = new ExceptionManager();
            _configurationProvider = new ConfigurationProvider();
            CONTEXT_AUTOMATE_PRODUCTION = _configurationProvider.ValueProduction;
            CONTEXT_AUTOMATE_DEVELOPPEMENT = _configurationProvider.ValueDeveloppement;

            //DoOnFirstLaunch();  //Lancement des initialisations d'automate
        }
        /// <summary>
        /// Singleton
        /// </summary>
        /// <returns></returns>
        public static ICore GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CoreImpl();
                InitInstanciation();
            }

            return _instance;
        }
        #endregion
    }
}
