using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMultilanguageByCsvSample2
{
    internal class LanguageProcess
    {
        private const string DefaultFileName = "Default.txt";
        public static ResourceDictionary Resources { get; private set; } = new ResourceDictionary();

        public static void SetLanguage(string path)
        {
            if (!File.Exists(path))
            {
                path = DefaultFileName;
            }

            foreach (var item in File.ReadLines(path).Select(line => line.Split(',')))
            {
                Resources[item[0]] = item[1];
            }
        }
    }


   
}
