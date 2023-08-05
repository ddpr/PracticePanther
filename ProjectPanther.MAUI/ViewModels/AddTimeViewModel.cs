using ProjectPanther.Library.Models;
using ProjectPanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.MAUI.ViewModels
{
    public class AddTimeViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshTimes()
        {
            NotifyPropertyChanged("Times");
        }
    }
}
