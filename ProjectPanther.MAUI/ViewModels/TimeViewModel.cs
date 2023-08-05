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
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; set; }
        public TimeViewModel SelectedTime { get; set; }
        public string Query { get; set; }

        public string HoursDisplay
        {
            get
            {
                return Model.Hours.ToString();
            }
            set
            {
                if(Decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                return new ObservableCollection<TimeViewModel>
                    (TimeService.Current.Times.Select(t => new TimeViewModel(t)));
            }
        }

        private Employee employee { get; set; }
        public Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                if (employee != null)
                {
                    Model.EmployeeId = employee.Id;
                }
            }
        }
        public String EmployeeDisplay => Employee?.Name ?? string.Empty;
        private Project project { get; set; }

        public Project Project
        {
            get
            {
                return project;
            }
            set
            {
                project = value;
                if(project != null)
                {
                    Model.ProjectId = project.Id;
                }
            }
        }
        public String ProjectDisplay => Project?.LongName ?? string.Empty;


        public ObservableCollection<Employee> Employees
        {
            get
            {
                return new ObservableCollection<Employee>(EmployeeService.Current.Employees);
            }
        }

        public ObservableCollection<Project> Projects
        {
            get
            {
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }

        public TimeViewModel()
        {
            Model = new Time();

        }

        public TimeViewModel(Time t)
        {
            Model = t;
            var employee = EmployeeService.Current.Get(t.EmployeeId);
            if(employee != null)
            {
                Employee = employee;
            }

            var project = ProjectService.Current.Get(t.ProjectId);
            if (project != null)
            {
                Project = project;
            }

        }

        public void Delete()
        {
            if (SelectedTime == null)
            {
                return;
            }
            TimeService.Current.Delete(SelectedTime.Model.Id);
            NotifyPropertyChanged("Times");
        }

        public void AddOrUpdate()
        {

            TimeService.Current.AddOrUpdate(Model);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
