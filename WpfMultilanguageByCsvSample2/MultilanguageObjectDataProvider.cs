using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfMultilanguageByCsvSample2
{
    public class MultilanguageObjectDataProvider : ObjectDataProvider
    {
        public MultilanguageObjectDataProvider()
        {
            var app = Application.Current as IMultilanguage;
            if (app != null)
            {
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
