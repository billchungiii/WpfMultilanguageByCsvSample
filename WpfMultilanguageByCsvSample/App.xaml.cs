using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMultilanguageByCsvSample
{


    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        public static LanguageCode CurrentLanguage { get; private set; }

        public static void SetCurrentLanguage(LanguageCode code)
        {
            if (code == LanguageCode.Default)
            {
                LanguageProcess.SetLanguage("Default.txt");
                CurrentLanguage = LanguageCode.Default;
            }
            else if (code == LanguageCode.zhtw)
            {
                LanguageProcess.SetLanguage("zh-tw.txt");
                CurrentLanguage = LanguageCode.zhtw;                
            }

           
        }

        public App()
        {
            SetCurrentLanguage(LanguageCode.Default);
            this.Resources.MergedDictionaries.Add(LanguageProcess.Resources);
        }
    }

    public enum LanguageCode
    {
        Default, zhtw
    }
}
