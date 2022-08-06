using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfMultilanguageByCsvSample2
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application, IMultilanguage
    {
        public LanguageProxy LanguageProxy { get; private set; }

        public App()
        {
            LanguageProxy = new LanguageProxy();
            this.Resources.MergedDictionaries.Add(LanguageProcess.Resources);
        }
    }

    public interface IMultilanguage
    {
        LanguageProxy LanguageProxy { get; }
    }


   

    
}


