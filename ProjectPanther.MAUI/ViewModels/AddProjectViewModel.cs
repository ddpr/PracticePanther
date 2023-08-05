using PracticeManagement.Library.Models;
using PracticePanther.Library.Services;
using ProjectPanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.MAUI.ViewModels
{
    public class AddProjectViewModel : INotifyPropertyChanged
    {
        public Project Model { get; set; }
        private int linkClientId { get; set; }

        public AddProjectViewModel(int clientId, int projectId)
        {
            if(clientId <= 0)
            {
                Model = new Project();
            }
            else
            {
                Model = ProjectService.Current.Get(projectId);
                if(Model == null)
                {
                    Model = new Project();
                }
                linkClientId = clientId;
            }
        }

        public AddProjectViewModel(int clientId, bool old)
        {
            Model = new Project();
            linkClientId = clientId;
        }

        public string LongNameEntry
        {
            get
            {  

                return Model.LongName;
            }

            set
            {
                Model.LongName = value;
            }
        }

        public string ShortNameEntry
        {
            get
            {

                return Model.ShortName;
            }

            set
            {
                Model.ShortName = value;
            }
        }

        public DateTime OpenDate
        {
            get
            {
                return Model.OpenDate;
            }
            set
            {
                Model.OpenDate = value;
            }
        }
        public DateTime CloseDate
        {
            get
            {
                return Model.CloseDate;
            }
            set
            {
                Model.CloseDate = value;
            }
        }
        public Boolean IsActive
        {
            get
            {
                return Model.IsActive;
            }
            set
            {
                Model.IsActive = value;
            }
        }

        public void Add()
        {
            if(Model.Id <= 0)
            {
                Model.linkedClient = ClientService.Current.Get(linkClientId);
                Model.ClientId = linkClientId;
                ProjectService.Current.Add(Model);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
