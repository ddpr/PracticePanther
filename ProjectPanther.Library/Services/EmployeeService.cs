using ProjectPanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        private static object _lock = new object();
        private List<Employee> employeelist;
        private int MaxId;

        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }
        }

        private EmployeeService()
        {
            employeelist = new List<Employee>()
            {
                new Employee() {Name = "Bobby", Rate = 500M, Id=1}
            };
        }

        public List<Employee> Employees
        {
            get {  return employeelist;}
        }

        public Employee? Get(int id)
        {
            return employeelist.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee? employee)
        {
            if(employee != null) 
            {
                if(employee.Id <=0)
                {
                    MaxId = employeelist.Any() ? employeelist.Select(e => e.Id).Max() : 0;
                    employee.Id = MaxId + 1;
                }

                employeelist.Add(employee);
            }
        }

        public void Delete(int id)
        {
            var emplyoeeToRemove = Get(id);
            if(emplyoeeToRemove != null)
            {
                employeelist.Remove(emplyoeeToRemove);
            }
        }

        public void Delete(Employee e)
        {
            Delete(e.Id);
        }

        public void Read()
        {
            employeelist.ForEach(Console.WriteLine);
        }

        public List<Employee> Search(string query)
        {
            return employeelist.Where(e => e.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
    }
}
