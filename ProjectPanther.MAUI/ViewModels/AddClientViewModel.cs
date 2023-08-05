using PracticeManagement.Library.Models;
using PracticePanther.Library.Services;
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
    public class AddClientViewModel : INotifyPropertyChanged
    {
        public Project SelectedProject { get; set; }

        public string NameEntry { 
            get
            {
                return Model.Name;
            }

            set
            {
                Model.Name = value;
            }
        }
        public DateTime OpenDate { 
            get 
            {
                return Model.OpenDate;
            } 
            set 
            { 
                Model.OpenDate = value;
            } 
        }
        public DateTime CloseDate { 
            get 
            {
                return Model.CloseDate;
            } 
            set 
            { 
                Model.CloseDate = value;
            } 
        }
        public Boolean IsActive { 
            get
            {
                return Model.IsActive;
            }
            set
            {
                Model.IsActive = value;
            }
        }
        public string Notes {
            get
            {
                return Model.Notes;
            }
            set
            {
                Model.Notes = value;
            }
        }

        public Client Model { get; set; }

        public void Add()
        {
            if (Model.Id <= 0)
            {
                ClientService.Current.Add(Model);
            }
        }

        public AddClientViewModel(int clientId)
        {
            if(clientId <=0)
            {
                Model = new Client();
            }
            else
            {
                Model = ClientService.Current.Get(clientId);
            }
        }

        public ObservableCollection<Project> Projects
        {
            get
            {  
               return new ObservableCollection<Project>(ProjectService.Current.ByClientId(Model.Id));
            }
        }

        public void DeleteProject()
        {
            if (SelectedProject == null)
            {
                return;
            }
            ProjectService.Current.Delete(SelectedProject);
            NotifyPropertyChanged("Projects");
        }

        public void Search()
        {
            NotifyPropertyChanged("Projects");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
