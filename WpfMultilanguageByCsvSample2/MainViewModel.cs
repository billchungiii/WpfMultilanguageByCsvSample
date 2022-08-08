using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMultilanguageByCsvSample2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Gender _selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Gender SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {                    
                    _selectedItem = value;                   
                    OnPropertyChanged(nameof(SelectedItem));                    
                }
            }

        }

        public ICommand ChangeLanguage
        {
            get { return new ChangedLangeageCommand(); }
        }
    }

    public class ChangedLangeageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var app = Application.Current as IMultilanguage;
            if (app == null ) { return; }
            var proxy = app.LanguageProxy;
            if (proxy.CurrentLanguage == LanguageCode.Default)
            {
                proxy.CurrentLanguage = LanguageCode.zhtw;
            }
            else
            {
                proxy.CurrentLanguage = LanguageCode.Default;
            }
        }
    }
}
