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
    internal class Recorder
    {
        // class designed as a singleton
        // there will always be only one instance

        private static Recorder instance = null;
        // locks for thread safety
        private static readonly object padlock = new object();
        private readonly object fileLock = new object();

        private string RecFileDir = $"{Directory.GetCurrentDirectory()}\\record";
        private string RecFile = $"EurofighterCockpit_MVrecording.txt";
        private TextBox RecBox = null;

        public static Recorder Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) instance = new Recorder();
                    return instance;
                }
            }
        }

        private Recorder()
        {
            if (!Directory.Exists(RecFileDir))
            {
                Directory.CreateDirectory(RecFileDir);
            }
            string path = Path.Combine(RecFileDir, RecFile);
            if (!File.Exists(path))
            {
                Console.WriteLine($"Recfile created: {path}");
                File.Create(path).Close();
            }
            RecToFile("Recording :)", true);
        }


        public void SetRecBox(TextBox RecBox)
        {
            this.RecBox = RecBox;
        }

        public void Rec(string message)
        {
            //RecToBox(message); //would be to much traffic
            RecToFile(message);
        }

        public void RecToFile(string message, bool raw = false)
        {
            // at this point we are sure the Rec file exists (see constructor)
            if (!raw)
            {
                message = $"[{DateTime.Now:T}] {message}";
            }

            try
            {
                lock (fileLock)
                {
                    File.AppendAllText(
                        Path.Combine(RecFileDir, RecFile),
                        message + Environment.NewLine,
                        Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                RecToBox($"ERROR in Rec file: {ex.Message}");
            }
        }

        public void RecToBox(string message)
        {
            if (RecBox == null) return;

            string formattedMessage = $"[{DateTime.Now.ToString("HH:mm:ss")}] {message}";
            if (!formattedMessage.EndsWith(Environment.NewLine))
                formattedMessage += Environment.NewLine;

            if (RecBox.IsHandleCreated)
            {
                RecBox.BeginInvoke(new Action(() => {
                    RecBox.AppendText(formattedMessage);
                    // scroll to last line if needed
                    RecBox.ScrollToCaret();
                }));
            }
        }

    }
}
