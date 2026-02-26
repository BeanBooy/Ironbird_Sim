using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EurofighterCockpit
{
    internal class Logger
    {
        // class designed as a singleton
        // there will always be only one instance

        private static Logger instance = null;
        // locks for thread safety
        private static readonly object padlock = new object();
        private readonly object fileLock = new object();

        private string logFileDir = $"{Directory.GetCurrentDirectory()}\\logs";
        private string logFile = $"EurofighterCockpit_{DateTime.Now:yyyy_MM_dd}.log";
        private TextBox logBox = null;

        public static Logger Instance {
            get {
                lock (padlock) {
                    if (instance == null) instance = new Logger();
                    return instance;
                }
            }
        }

        private Logger() {
            if (!Directory.Exists(logFileDir)) {
                Directory.CreateDirectory(logFileDir);
            }
            string path = Path.Combine(logFileDir, logFile);
            if (!File.Exists(path)) {
                Console.WriteLine($"Logfile created: {path}");
                File.Create(path).Close();
            }
            LogToFile("", true);
            LogToFile("###################################################################", true);
            LogToFile($"### LOGGER INSTANCE CREATED  ({DateTime.Now:yyyy_MM_dd} {DateTime.Now:T})", true);
            LogToFile("###################################################################", true);
        }


        public void SetLogBox(TextBox logBox) {
            this.logBox = logBox;
        }

        public void Log(string message) {
            LogToBox(message);
            LogToFile(message);
        }

        public void LogToFile(string message, bool raw = false) {
            // at this point we are sure the log file exists (see constructor)
            if (!raw) {
                message = $"[{DateTime.Now:T}] {message}";
            }

            try {
                lock (fileLock) {
                    File.AppendAllText(
                        Path.Combine(logFileDir, logFile),
                        message + Environment.NewLine,
                        Encoding.UTF8);
                }
            }
            catch (Exception ex) {
                LogToBox($"ERROR in log file: {ex.Message}");
            }
        }

        public void LogToBox(string message) {
            if (logBox == null) return;

            string formattedMessage = $"[{DateTime.Now.ToString("HH:mm:ss")}] {message}";
            if (!formattedMessage.EndsWith(Environment.NewLine))
                formattedMessage += Environment.NewLine;

            if (logBox.IsHandleCreated) {
                logBox.BeginInvoke(new Action(() => {
                    logBox.AppendText(formattedMessage);
                    // scroll to last line if needed
                    logBox.ScrollToCaret();
                }));
            }
        }

    }
}
