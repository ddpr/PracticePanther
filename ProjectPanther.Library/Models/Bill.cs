using PracticeManagement.Library.Models;
using ProjectPanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.Library.Models
{
    public class Bill
    {

        //public List<Project> linkedProjects = new List<Project>();
        public Project? linkedProject { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime DueDate { get; set; }

        public Bill()
        {
            TotalAmount = calculateTotal();
            DueDate = DateTime.Today.AddDays(31);
        }

        public decimal calculateTotal()
        {
            decimal total = 0;
            if (linkedProject != null) {
            foreach(var entry in linkedProject.timeEntries)
                {
                    var emplyoee = EmployeeService.Current.Get(entry.EmployeeId);
                    if(emplyoee != null) {

                        total = total + (emplyoee.Rate * entry.Hours);
                    }
                }
        }
            return total;
        }


        public override string ToString()
        {
            return $"Due Date: {DueDate}" +
                $"\n${TotalAmount}";
        }
    }
}
