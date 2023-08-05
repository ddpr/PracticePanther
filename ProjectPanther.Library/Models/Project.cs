using PracticeManagement.Library.Models;
using ProjectPanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{

    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set;}
        public DateTime CloseDate { get; set;}
        public Boolean IsActive { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ClientId { get; set; }
        public Client? linkedClient { get; set; }
        public string ClientName { get; set; }
        public List<Time> timeEntries = new List<Time> { };

        public Project()
        {
            OpenDate = DateTime.Today;
            CloseDate = DateTime.Today.AddDays(365);
        }

        //Override the Object.ToString() function.
        //This allows us to format the output when a Project class is parsed as a string (i.e. when passed in Console.WriteLine())
        //Can do this because ToString() is a virtual function on the Object Class that our Project is derived from.
        public override string ToString()
        {
            return $"-{ShortName} ({LongName}) Id:{Id}\n";
            //return $"\n////////////////////////\nID:{Id} \nName:{ShortName} ({LongName}) \nLinked Client: {ClientId} \nClient Name: {ClientName} \nActive(?): " +
                //$"{IsActive} \nStart Date: {OpenDate}\nClose Date: {CloseDate}\n////////////////////////";
        }//end of ToString() override

    }
}
