using System;

namespace PersonalClassLib.Core.Routage
{
    /// <summary>
    /// Gestion des Exceptions liées à la l'injection de Dépendance
    /// </summary>
    [Serializable]
    public class RouteNotFoundException : Exception
    {
        public RouteNotFoundException() { }
        public RouteNotFoundException(string message) : base(message) { }
        public RouteNotFoundException(Type type) : base($"La route n'existe pas pour le type : {type.FullName}") { }
        public RouteNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected RouteNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
