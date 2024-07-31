namespace PersonalClassLib.Core.Routage
{
    /// <summary>
    /// Classe ayant pour Rôle l'Injection de Dépendance
    /// </summary>
    public interface IRouter
    {
        /// <summary>
        /// Retourne le domaine d'activité demandé par le paramètre générique. T doit être l'interface du domaine à retourner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>L'implémentation du domain qui est renseigné dans le fichier de configuration xml</returns>
        T GetDomain<T>();
    }
}
