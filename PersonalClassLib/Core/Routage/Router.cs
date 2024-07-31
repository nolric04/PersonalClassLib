using System;
using System.Collections.Generic;

namespace PersonalClassLib.Core.Routage
{
    /// <summary>
    /// Gestionnaire des Routes
    /// </summary>
    public class Router : IRouter
    {
        private IDictionary<Type, Type> _activeRoutes = null;
        ICore _core = CoreImpl.GetInstance();

        /// <summary>
        /// Fourni un dictionnaire de paires 'Interface'-'Implementation' des différentes routes paramétrées 
        /// dans le fichiers de confguration XML
        /// </summary>
        protected virtual IDictionary<Type, Type> ActiveRoutes
        {
            get
            {
                // Dictionnaire en Singleton 
                if (_activeRoutes == null)
                {
                    _activeRoutes = _core.GetConfigurationProvider().GetActiveDomains;
                }
                return _activeRoutes;
            }
        }

        /// <inheritdoc/>
        public T GetDomain<T>()
        {
            try
            {
                // Utilisation de l'activator qui permet l'instanciation du classe par un System.Type
                return (T)Activator.CreateInstance(ActiveRoutes[typeof(T)]);
            }
            catch (KeyNotFoundException)
            {
                // Si l'interface n'est pas référencée
                throw new RouteNotFoundException(typeof(T));
            }
            catch (Exception ex)
            {
                _core.GetExceptionManager().ThrowError(100, new Dictionary<string, string> { { "Type d'Exception", ex.InnerException.ToString() }, { "message", ex.Message } });
                throw;
            }
        }
    }
}
