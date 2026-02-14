using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EurofighterCockpit
{
    internal class Logger
    {
        private string logFileDir = $"{Directory.GetCurrentDirectory()}\\logs";
        private string logFile = $"EurofighterCockpit_{DateTime.Now:yyyy_MM_dd}.log";

        public Logger() {

            try {
                if (!Directory.Exists(logFileDir)) {
                    Directory.CreateDirectory(logFileDir);
                }
                string path = Path.Combine(logFileDir, logFile);
                if (!File.Exists(path)) {
                    Console.WriteLine($"Logfile created: {path}");
                    File.Create(path).Close();
                }
                log("", true);
                log("###################################################################", true);
                log($"### LOGGER INSTANCE CREATED  ({DateTime.Now:yyyy_MM_dd} {DateTime.Now:T})", true);
                log("###################################################################", true);
            }
            catch {
                //nothing here
            }
        }

        public void log(string message, bool raw = false) {
            // at this point we are sure the log file exists (see constructor)
            if (!raw) {
                message = $"[{DateTime.Now:T}] {message}";
            }
            try {
                File.AppendAllText(Path.Combine(logFileDir, logFile), $"{message}{Environment.NewLine}", Encoding.UTF8);
            }
            catch {
                //nothing here 
            }
        }
    }
}
