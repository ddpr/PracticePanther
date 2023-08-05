using PracticeManagement.Library.Models;
using ProjectPanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private static object _lock = new object();
        private List<Project> projectsList;
        private List<Project> emptyProjectsList;
        private int MaxId;

        public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                            instance = new ProjectService();
                    }
                    return instance;
                }
            }
        }

        private ProjectService()
        {
            projectsList = new List<Project>()
            {
                //Id, OpenDate, CloseDAte,IsActive, ShortName, LongName,ClientId, linkedClient, ClientName
                new Project() {Id = 1, ShortName = "Proj1", LongName = "Project 1", ClientId= 1},
                new Project() {Id = 2, ShortName = "Proj2", LongName = "Project 2"},
                new Project() {Id = 3, ShortName = "Proj3", LongName = "Project 3"}
            };
            
            //Used for when client is being added to return an empty list
            emptyProjectsList = new List<Project>() { };
        }

        public List<Project> Projects
        {
            get { return projectsList; }
        }

        public Project? Get(int projectId)
        {
            return projectsList.FirstOrDefault(p => p.Id == projectId);
        }

        public void Add(Project? project)
        {
            if(project != null)
            {
                if(project.Id <= 0)
                {
                    MaxId = projectsList.Any() ? projectsList.Select(c => c.Id).Max() : 0;
                    project.Id = MaxId + 1;
                }
               projectsList.Add(project);
            }
        }

        public void Delete(int id)
        {
            var projectToRemove = Get(id);
            if(projectToRemove!= null)
            {
                projectsList.Remove(projectToRemove);
            }
        }
        public void Delete(Project p)
        {
            Delete(p.Id);
        }
        public void Read()
        {
            projectsList.ForEach(Console.WriteLine);
        }
        public List<Project> Search(string query)
        {
            return projectsList.Where(p => p.LongName.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public List<Project> ByClientId(int clientId)
        {
            if(clientId <= 0)
            {
                return emptyProjectsList;
            }
            return projectsList.Where(p => p.ClientId == clientId).ToList();
        }


        //Function that searches through the list of projects and finds the one with the provided 
        //projectId and adds the passed Time entry to it's timeEntriesList
        public void AddTimeEntry(Time t, int projectId)
        {
            var projectToAddEntry = projectsList.FirstOrDefault(p => p.Id == projectId);
            if(projectToAddEntry != null)
            {
                projectToAddEntry.timeEntries.Add(t);
            }
        }
    }
}
