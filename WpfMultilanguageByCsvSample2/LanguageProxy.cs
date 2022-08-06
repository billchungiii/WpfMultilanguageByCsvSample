using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfMultilanguageByCsvSample2
{
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

    public enum LanguageCode
    {
        [Description("Default.txt")]
        Default,
        [Description("zh-tw.txt")]
        zhtw
    }

    public class LanguageChangedEventArgs : EventArgs
    {
        public LanguageChangedEventArgs(LanguageCode languageCode)
        {
            LanguageCode = languageCode;
        }
        public LanguageCode LanguageCode { get; private set; }
    }
}
