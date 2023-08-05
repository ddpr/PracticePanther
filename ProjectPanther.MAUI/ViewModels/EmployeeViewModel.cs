using PracticeManagement.Library.Models;
using PracticePanther.Library.Services;
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
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        public Employee SelectedEmployee { get; set; }

        public string Query { get; set; }


        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Employee>(EmployeeService.Current.Employees);

                }
                return new ObservableCollection<Employee>(EmployeeService.Current.Search(Query));
            }
        }

        public void Delete()
        {
            if (SelectedEmployee == null)
            {
                return;
            }
            EmployeeService.Current.Delete(SelectedEmployee);
            NotifyPropertyChanged("Employees");
        }

        public void Search()
        {
            NotifyPropertyChanged("Employees");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
