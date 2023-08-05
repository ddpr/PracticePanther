using ProjectPanther.Library.Models;
using ProjectPanther.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.MAUI.ViewModels
{
    class AddEmployeeViewModel : INotifyPropertyChanged
    {
        public Employee Model { get; set; }
        public AddEmployeeViewModel(int employeeId)
        {
            if (employeeId <= 0)
            {
                Model = new Employee();
            }
            else
            {
                Model = EmployeeService.Current.Get(employeeId);
            }
        }

        public string NameEntry
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }

        public decimal RateEntry
        {
            get
            {
                return Model.Rate;
            }
            set
            {
                Model.Rate = value;
            }
        }

        public void Add()
        {
            if(Model.Id <=0)
            {
                EmployeeService.Current.Add(Model);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
