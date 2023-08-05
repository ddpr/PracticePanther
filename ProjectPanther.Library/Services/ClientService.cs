//Singleton Class for  Clients

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PracticeManagement.Library.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance; //static ClientService object that serves as the instance that gets returned whenever its called and an instance is not already made
        private static object _lock = new object();
        private List<Client> clientslist;   //List that actually holds the list of clients
        private int MaxId;
        public static ClientService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }
                return instance;

            }
        }

        private ClientService()
        {
            clientslist = new List<Client>()
            {
                new Client {Id = 1, Name = "John Smith"},
                new Client {Id = 2, Name = "Jane Doe"},
                new Client {Id = 3, Name = "Bob Ross"}
            };

        }

        public List<Client> Clients
        {
            get { return clientslist; }
        }

        public Client? Get(int id)
        {
            return clientslist.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Client? client) 
        {
            if(client != null)
            {
                if(client.Id <= 0)
                {
                    MaxId = clientslist.Any() ? clientslist.Select(c => c.Id).Max() : 0;
                    client.Id = MaxId + 1;
                }
                clientslist.Add(client);
            }
        }

        public void Delete(int id)
        {
            var clientToRemove = Get(id);
            if(clientToRemove != null)
            {
                clientslist.Remove(clientToRemove);
            }
        }

        public void Delete(Client c)
        {
            Delete(c.Id);  
        }

        public void Read()
        {
            clientslist.ForEach(Console.WriteLine);
        }

        public List<Client> Search(string query)
        {
            return clientslist.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
    }
}
