using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using PersonalClassLib.Core.Configuration.DTO;

namespace PersonalClassLib.Core.Configuration
{
    /// <summary>
    /// Classe de récupération de toutes les configurations utiles à DNATOR
    ///     - Ranorex Test Suite
    ///     - Ranorex app.conf
    ///     - DNATOR ConfFiles
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider
    {
        #region Constantes
        private const string GLOBAL_CONTEXT_PROJECT = "Nom_VariableGlobale_ContextProject";
        private const string KEY_CONTEXT_DEVELOPPEMENT = "Developpement";
        private const string KEY_CONTEXT_PRODUCTION = "Production";
        #endregion
        
        #region Variables
        private IDictionary<Type, Type> _activeDomains = null;
        private IDictionary<string, DtoVariablesEnvironnement> _environment = null;
        private IDictionary<int, string> _errorMessages = null;
        private string _contextDevProd = null;
        private ICore _core = CoreImpl.GetInstance();
        #endregion
        

        public string ValueDeveloppement => GetEnvironment[GLOBAL_CONTEXT_PROJECT].ListeValeurs[KEY_CONTEXT_DEVELOPPEMENT];
        public string ValueProduction => GetEnvironment[GLOBAL_CONTEXT_PROJECT].ListeValeurs[KEY_CONTEXT_PRODUCTION];

        /// <inheritdoc/>
        public IDictionary<Type, Type> GetActiveDomains
        {
            get
            {
                // Uniquement au premier lancement
                if (_activeDomains == null)
                {
                    _activeDomains = new Dictionary<Type, Type>();

                    // Chargement du document avec la clé du fichier env.xml
                    var xml = GenerateXDocument(GetDomain());
                    // Récupération des éléments
                    var childList =
                        from el in xml.Root.Elements()
                        select el;


                    foreach (var node in childList)
                    {
                        // Pour chaque éléments, on récupère le node 'interface' et le node 'implementation'

                        var interfac = node.Elements().Where(e => e.Name == "interface").SingleOrDefault().Value;
                        var impl = node.Elements().Where(e => e.Name == "implementation").SingleOrDefault().Value;
                        // On l'enregistre dans le dictionnaire
                        _activeDomains[Type.GetType(interfac, true, true)] = Type.GetType(impl, true, true);
                    }
                }

                return _activeDomains;
            }
        }

        /// <inheritdoc/>
        private IDictionary<string, DtoVariablesEnvironnement> GetEnvironment
        {
            get
            {
                // Uniquement au premier lancement
                if (_environment == null)
                {
                    _environment = new Dictionary<string, DtoVariablesEnvironnement>();
                    
                    
                    // Chargement du fichier env.xml
                    var xml = GenerateXDocument(GetEnv());
                    // On récupère tout les éléments
                    var childList =
                        from el in xml.Root.Elements()
                        select el;
                    //Navigation ConfigFiles / ConfigVariables
                    foreach (var nodeNiveau1 in childList)
                    {
                        //Navigation dans les niveaux secondaires
                        foreach (var node in nodeNiveau1.Elements())
                        {
                            //DTO pour ranger les informations récupérées
                            var dto = new DtoVariablesEnvironnement();
                            var key = node.Attribute("key");
                            // name pas obligatoire
                            dto.NomParametre = node.Attribute("name")?.Value.Trim();
                            node.Elements("value").ToList().ForEach(e =>
                            {
                                var cleValue = "";
                                if (nodeNiveau1.Name == "configFiles")
                                {
                                   cleValue = e.Value.Split('/').Last().ToString().Split('.')[0];
                                }

                                if (nodeNiveau1.Name == "configVariables")
                                {
                                    cleValue = e.Attribute("key")?.Value.Trim();
                                }
                                dto.ListeValeurs.Add(cleValue, e.Value.Trim());
                                if (e.Elements().ToList().Exists(eNiveau1 => eNiveau1.Name == "default"))
                                {
                                    dto.DefaultValue = e.Value.Trim();
                                }
                            });

                            // Que l'on enregistre dans le dictionnaire.
                            _environment[key.Value] = dto;
                        }
                    }
                    
                }
                return _environment;
            }
        }

        /// <inheritdoc/>
        public IDictionary<int, string> GetErrorMessages
        {
            get
            {
                // Uniquement au premier lancement
                if (_errorMessages == null)
                {
                    // Chargement du document avec la clé du fichier env.xml
                    _errorMessages = new Dictionary<int, string>();
                    XDocument xml = GenerateXDocument(GetErrors());
                    // On récupère tout les éléments
                    var childList =
                        from el in xml.Root.Elements()
                        select el;
                    foreach (var node in childList)
                    {
                        var code = node.Attribute("code").Value;
                        // Pour chaque élément, on récupère les node et on extrait le 'code' en attribut et le 'message' en value.
                        var message = node.Value;
                        _errorMessages[int.Parse(code)] = message;
                    }
                }

                return _errorMessages;
            }
        }

        public static XDocument GenerateXDocument(string content)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            return XDocument.Load(stream);
        }

        /// <summary>
        /// Retourne la ressource domains située dans le dossier de fichiers de configuration
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDomain()
        {
            return Resource.domains;
        }

        /// <summary>
        /// Retourne la ressource env située dans le dossier de fichiers de configuration
        /// </summary>
        /// <returns></returns>
        protected virtual string GetEnv()
        {
            return Resource.env;
        }

        /// <summary>
        /// Retourne la ressource errors située dans le dossier de fichiers de configuration
        /// </summary>
        /// <returns></returns>
        protected virtual string GetErrors()
        {
            return Resource.errors;
        }
    }
}