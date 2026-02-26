using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace EurofighterCockpit
{
    internal class Config
    {
        // class designed as a singleton
        // there will always be only one instance

        private static Config instance = null;
        // lock for thread safety
        private static readonly object padlock = new object();
        private static Logger logger = Logger.Instance;

        private Dictionary<string, string> dict;

        public static Config Instance {
            get {
                lock (padlock) {
                    if (instance == null) instance = new Config();
                    return instance;
                }
            }
        }

        public Dictionary<string, string> Dict { get => dict; }

        public void setConfig(string configPath) {
            if (File.Exists(configPath) == false) {
                logger.Log($"Unvalid config path: {configPath}");
                return;
            }
            try {
                string json = File.ReadAllText(configPath);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dict = serializer.Deserialize<Dictionary<string, string>>(json);
            }
            catch (Exception ex) {
                logger.Log($"ERROR while reading config file: {configPath}");
                logger.Log(ex.Message);
            }
        }


    }
}
