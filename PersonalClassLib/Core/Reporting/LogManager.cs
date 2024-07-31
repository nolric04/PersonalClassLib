using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalClassLib.Core.Reporting
{
    /// <summary>
    /// Classe de gestion des Logs de Dnator
    /// </summary>
    public class LogManager : ILogManager
    {
        private string _dernierMessage;

        public string DernierMessage
        {
            get
            {
                return _dernierMessage;
            }
        }

        private IDictionary<int, string> _logMessages => CoreImpl.GetInstance().GetConfigurationProvider().GetErrorMessages;
        
        /// <inheritdoc/>
        public void Info(int code)
        {
            Info(code, null);
        }

        /// <inheritdoc/>
        public void Info(int code, IDictionary<string, string> options)
        {
            var str = ConstructionMessage(code, options);
            _dernierMessage = str;
            Console.WriteLine(str);
        }

        /// <inheritdoc/>
        public void Success(int code)
        {
            Success(code, null);
        }

        /// <inheritdoc/>
        public void Success(int code, IDictionary<string, string> options)
        {
            var str = ConstructionMessage(code, options);
            _dernierMessage = str;
            Console.WriteLine(str);
        }
        
        /// <inheritdoc/>
        public void Warn(int code)
        {
            Warn(code, null);
        }

        /// <inheritdoc/>
        public void Warn(int code, IDictionary<string, string> options)
        {
            var str = ConstructionMessage(code, options);
            _dernierMessage = str;
            Console.WriteLine(str);
        }
        
        /// <inheritdoc/>
        public void Error(int code)
        {
            Error(code, null);
        }

        /// <inheritdoc/>
        public void Error(int code, IDictionary<string, string> options)
        {
            var str = ConstructionMessage(code, options);
            _dernierMessage = str;
            Console.WriteLine(str);
        }
        private string ConstructionMessage(int code, IDictionary<string, string> options)
        {
            var str = new StringBuilder();
            str.Append(_logMessages[code]);
            if (options == null) return str.ToString();
            str.Append("\r\n");
            foreach (var option in options)
            {
                // str.Append("\r\n");
                str.Append($"   | {option.Key}  =>  {option.Value}");
            }

            return str.ToString();
        } 
    }
    
    
}
