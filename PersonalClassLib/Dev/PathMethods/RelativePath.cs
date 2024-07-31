using System;
using System.Linq;

namespace PersonalClassLib.Dev.PathMethods
{
    /// <inheritdoc cref="IRelativePath" />
    internal class RelativePath : IRelativePath
    {
        /// <inheritdoc cref="IRelativePath.ConvertAbsolutePath"/>
        public string ConvertAbsolutePath(string relativePath)
        {
            //Split chemin Executable
            var splittedPath = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            //Recupere nombre retours arriere chemin relatif
            var nbRetourArriere = relativePath.Split('\\').Count(str => str == "..");
            var relPathSeparated = splittedPath.ToList();
            for (var i = 0; i < nbRetourArriere; i++)
            {
                relPathSeparated.RemoveAt(relPathSeparated.Count-1);
            }

            return relPathSeparated.ToList().Aggregate((k, v) => k + '\\' + v)
                   + '\\'
                   + relativePath.Split('\\')
                       .Where(elem => elem != "..")
                       .Aggregate((k, v) => k + '\\' + v);
        }
        
        /// <inheritdoc cref="IRelativePath.IsCheminRelatif"/>
        public bool IsCheminRelatif(string path)
        {
            return path[0] == '.' && path[1] == '.';
        }
    }
}