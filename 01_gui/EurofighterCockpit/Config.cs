using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

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

        public void loadConfig(string configPath) {
            if (File.Exists(configPath) == false) {
                MessageBox.Show($"Unvalid config path!\n{configPath} does not exist!", "Unvalid config path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log($"Unvalid config path!\n{configPath} does not exist!");
                return;
            }
            try {
                string json = File.ReadAllText(configPath);
                dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
            catch (Exception ex) {
                logger.Log($"ERROR while reading config file: {configPath}");
                logger.Log(ex.Message);
            }
        }

        public bool isConfigFileValid() {

            if (Dict != null && !File.Exists(Dict["defaultVideoPath"]))
                logger.Log("Unvalid video file in config file");
            if (Dict != null && !File.Exists(Dict["moviePath"]))
                logger.Log("Unvalid movie file in config file");
            if (Dict != null && !File.Exists(Dict["movieInputPath"]))
                logger.Log("Unvalid movie input file in config file");

            if (Dict != null &&
                Dict.ContainsKey("ipAddress") &&
                Dict.ContainsKey("port") &&
                Dict.ContainsKey("defaultVideoPath") &&
                Dict.ContainsKey("moviePath") &&
                Dict.ContainsKey("movieInputPath"))
                return true;
            return false;
        }
    }
}
