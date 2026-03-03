using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EurofighterCockpit
{
    internal class Recording
    {
        private string RecFileDir = $"{Directory.GetCurrentDirectory()}\\record";
        private string RecFile = $"EurofighterCockpit_MVrecording.txt";

        public int[] ParseToIntArr(string line)
        {
            int[] values = line.Split(',').Select(int.Parse).ToArray();
            return values;
        }

        public void PlayRecording()
        {
            string path = Path.Combine(RecFileDir, RecFile);
            foreach (string line in File.ReadLines(path))
            {
                int[] values = ParseToIntArr(line);
                
            }
        }
    }
}
