using PracticeManagement.Library.Models;
using ProjectPanther.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private List<Time> timesList;

        public List<Time> Times
        {
            get
            {
                return timesList;
            }
        }

        public static TimeService Current
        {
            get
            {
                if(instance == null)
                {
                    instance = new TimeService();
                }
                return instance;
            }
        }
        private TimeService()
        {
            timesList = new List<Time> {
                new Time{Id =1, EmployeeId =1, ProjectId = 1, Hours = 1.75M, Narrative = "Test Time Entry" },
                new Time{Id =2, EmployeeId =1, ProjectId = 1, Hours = 1.25M, Narrative = "Another Test Time Entry" }
            };
        }

        public Time AddOrUpdate(Time t)
        {
            timesList.Add(t);
            return t;
        }
        
        public Time? Get(int id)
        {
            return timesList.FirstOrDefault(t => t.Id == id);
        }
        public void Delete(int id)
        {
            var timeToDelete = Get(id);
            if (timeToDelete != null)
            {
                timesList.Remove(timeToDelete);
            }
        }


        public void Delete(Time t)
        {
            Delete(t.Id);
        }

    }
}
