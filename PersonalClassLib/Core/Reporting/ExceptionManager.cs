using System;
using System.Collections.Generic;

namespace PersonalClassLib.Core.Reporting
{
    /// <summary>
    /// Gestionnaire d'Exceptions
    /// </summary>
    public class ExceptionManager : IExceptionManager
    {
        private readonly ILogManager _log = CoreImpl.GetInstance().GetLogManager();
        /// <summary>
        /// Constructeur de classe
        /// </summary>
        public ExceptionManager()
        {
        }

        /// <inheritdoc/>
        public void ThrowError(int code)
        {
            ThrowError(code, null);
        }

        /// <inheritdoc/>
        public void ThrowError(int code, IDictionary<string, string> options)
        {
            _log.Error(code,options);
            throw new Exception(_log.DernierMessage);
        }

        /// <inheritdoc/>
        public void ThrowWarn(int code)
        {
            ThrowWarn(code, null);
        }

        /// <inheritdoc/>
        public void ThrowWarn(int code, IDictionary<string, string> options)
        {
            _log.Warn(code,options);
        }
    }
}
