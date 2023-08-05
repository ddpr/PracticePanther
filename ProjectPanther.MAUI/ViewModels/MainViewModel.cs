using PracticeManagement.Library.Models;
using PracticePanther.Library.Services;
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
    public class MainViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }

        public string Query { get; set; }


        public ObservableCollection<Client> Clients
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Client>(ClientService.Current.Clients);

                }
                return new ObservableCollection<Client>(ClientService.Current.Search(Query));
            }
        }

        public void Delete()
        {
            if(SelectedClient == null)
            {
                return;
            }
            ClientService.Current.Delete(SelectedClient);
            NotifyPropertyChanged("Clients");
        }

        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
