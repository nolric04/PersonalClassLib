using System.Collections.Generic;

namespace PersonalClassLib.Core.Configuration.DTO
{
    public class DtoVariablesEnvironnement
    {
        private string _nomParametre = "";
        private Dictionary<string,string> _listeValeurs = new Dictionary<string, string>();
        private string _defaultValue = "";

        public string NomParametre
        {
            get => _nomParametre;
            set => _nomParametre = value;
        }

        public Dictionary<string, string> ListeValeurs
        {
            get => _listeValeurs;
        }

        public string DefaultValue
        {
            get => _defaultValue;
            set => _defaultValue = value;
        }
    }
}