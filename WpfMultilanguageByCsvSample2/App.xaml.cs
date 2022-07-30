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

    public enum LanguageCode
    {
        [Description("Default.txt")]
        Default,
        [Description("zh-tw.txt")]
        zhtw
    }

    public class LanguageProxy 
    {
        public event EventHandler<LanguageChangedEventArgs> LanguageChanged;
       
        public LanguageProxy()
        {
            _currentLanguage = LanguageCode.Default;
            SetCurrentLanguage();
        }

        private LanguageCode _currentLanguage;

        public LanguageCode CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    SetCurrentLanguage();
                    LanguageChanged?.Invoke(this, new LanguageChangedEventArgs(value));
                }
            }
        }

        private void SetCurrentLanguage()
        {
            var field = typeof(LanguageCode).GetField(CurrentLanguage.ToString());
            if (field != null)
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (attribute != null)
                {
                    LanguageProcess.SetLanguage(attribute.Description);
                }
            }
        }
    }

    public class LanguageChangedEventArgs : EventArgs
    {
        public LanguageChangedEventArgs(LanguageCode languageCode)
        {
            LanguageCode = languageCode;
        }
        public LanguageCode LanguageCode { get; private set; }
    }

    public class MultilanguageObjectDataProvider : ObjectDataProvider
    {
        public MultilanguageObjectDataProvider()
        {
            var app = Application.Current as IMultilanguage;
            if (app != null)
            {
                //app.LanguageProxy.LanguageChanged +=WeakEventManager <LanguageProxy,LanguageCode>.AddHandler ()
                EventHandler<LanguageChangedEventArgs> handler = new EventHandler<LanguageChangedEventArgs>(LanguageProxy_LanguageChanged);
                WeakEventManager<LanguageProxy, LanguageChangedEventArgs>.AddHandler(app.LanguageProxy, "LanguageChanged", handler);
            }
        }

        private void LanguageProxy_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            this.Refresh();
        }
    }
}


