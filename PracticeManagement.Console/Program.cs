using System;
using System.Text;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography;
using PracticeManagement.CLI.Models;
using PracticePanther.Library.Services;

namespace PracticeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var projectList = new List<Project>();
            while (true)
            {
                Console.WriteLine("=================<Main Menu>=================");
                Console.WriteLine("P. Project Menu");
                Console.WriteLine("C. Client Menu");
                Console.WriteLine("Q. Quit Application");
                Console.WriteLine("=================<Main Menu>=================");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Open Project Menu
                    ProjectMenu(projectList);
                }
                else if(choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Open Client Menu
                    ClientMenu();
                }
                else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Close Application
                    Console.WriteLine("Exiting Application...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }//end of main()

        static void ClientMenu()
        {
            var myClientService = ClientService.Current;

            while (true)
            {
                Console.WriteLine("\n=================<Client Menu>=================");
                Console.WriteLine("C. Create a Client");
                Console.WriteLine("R. Read Clients");
                Console.WriteLine("U. Update a Client");
                Console.WriteLine("D. Delete a Client");
                Console.WriteLine("Q. Quit Menu");
                Console.WriteLine("=================<Client Menu>=================");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Create Clients
                    Console.Write("Id (Integer): ");
                    var Id = int.Parse(Console.ReadLine() ?? "0000");

                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    //Uses a Boolean variable that gets set after evaluation user input stored in the string variable activeString
                    Console.Write("Is The Client Active?\n1 = True\n0 = False\nStatus?: ");
                    var activeString = Console.ReadLine() ?? "0";

                    Console.Write("Start Date: ");
                    var startDate = Console.ReadLine() ?? DateTime.Today.ToString();

                    Console.Write("End Date: ");
                    var endDate = Console.ReadLine() ?? DateTime.Today.ToString();

                    Console.Write("Notes: ");
                    var notes = Console.ReadLine();

                    var myClient = new Client
                    {
                        Id = Id,
                        Name = name ?? "John/Jane Doe",
                        IsActive = UpdateActive(Convert.ToInt32(activeString)),
                        OpenDate = DateTime.Parse(startDate),
                        CloseDate = DateTime.Parse(endDate),
                        Notes = notes ?? ""
                    };

                    myClientService.Add(myClient);
                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Read Clients

                    myClientService.Read();

                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Update Client
                    Console.WriteLine("Which Client To Update?: ");

                    myClientService.Read();

                    var updateChoice = int.Parse(Console.ReadLine() ?? "0000");

                    var clientToUpdate = myClientService.Get(updateChoice);

                    if(clientToUpdate != null)
                    { 
                        UpdateClient(clientToUpdate); 
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Provided Client Not Found");
                    }

                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Please input the ID of the client to delete: ");

                    myClientService.Read();

                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToDelete = myClientService.Get(deleteChoice);

                    myClientService.Delete(deleteChoice);

                }
                else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Exit Client Menu by breaking while loop
                    break;
                }
                else
                {
                    //Handles invalid inputs and loops back to the top.
                    Console.WriteLine("Invalid Input.");
                }//end of if statement

            }//end of while loop

        }//end of ClientMenu()

        static void ProjectMenu(List<Project> projectList)
        {
            var myClientService = ClientService.Current;
            //Project: Id, OpenDate,  CloseDate, IsActive, ShortName, LongName, ClientId
            while (true)
            {
                Console.WriteLine("\n=================<Project Menu>=================");
                Console.WriteLine("C. Create a Project");
                Console.WriteLine("R. List Project");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("L. Link To Existing Client");
                Console.WriteLine("Q. Quit Menu");
                Console.WriteLine("=================<Project Menu>=================\n");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Create Project

                    //Initialize Properties Through User Input

                    //Set ID to 0000 if null input
                    Console.Write("Id (Integer): ");
                    var Id = int.Parse(Console.ReadLine() ?? "0000");

                    Console.Write("LongName: ");
                    var lName = Console.ReadLine();

                    Console.Write("ShortName: ");
                    var sName = Console.ReadLine();

                    //Set activeString to 0 if null input
                    Console.Write("Is The Project Active?\n1 = True\n0 = False\nStatus?: ");
                    var activeString = Console.ReadLine() ?? "0";

                    Console.WriteLine("Start Date: ");
                    var startDate = Console.ReadLine();

                    Console.WriteLine("End Date: ");
                    var endDate = Console.ReadLine();

                    var myProject = new Project
                    {
                        Id = Id,
                        OpenDate = DateTime.Parse(startDate ?? DateTime.Today.ToString()),
                        CloseDate = DateTime.Parse(endDate ?? DateTime.Today.ToString()),
                        IsActive = UpdateActive(Convert.ToInt32(activeString)),
                        ShortName = sName ?? "REDACTED",
                        LongName = lName ?? "REDACTED",
                        ClientName = "REDACTED"
                    };

                    projectList.Add(myProject);
                }

                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Read Projects

                    //I opted to use this method of printing the list this way because I like how the structure of it looks (makes more sense visually).
                    //The .ForEach LINQ method version is cool as well and I use it in the Update sections to condense code.
                    foreach (var project in projectList)
                    {
                        Console.WriteLine(project);
                    }

                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which Project To Update?: ");

                    projectList.ForEach(Console.WriteLine);

                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToUpdate = projectList.FirstOrDefault(c => c.Id == updateChoice);

                    if (projectToUpdate != null)
                    {
                        UpdateProject(projectToUpdate);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Provided Project Not Found");
                    }


                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which Project To Delete?: ");

                    projectList.ForEach(Console.WriteLine);

                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToDelete = projectList.FirstOrDefault(c => c.Id == deleteChoice);

                    if (projectToDelete != null)
                    {
                        projectList.Remove(projectToDelete);
                    }

                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Exit Menu by breaking while loop
                    break;
                }
                else if(choice.Equals("L", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Link A Client to A Project
                    //LinkClient(projectList, clientList);
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }//end of if statement

            }//end of while loop

        }//end of ProjectMenu()

        static void UpdateClient(Client client)
        {
            Console.WriteLine("Properties:" +
                "\nI - ID" +
                "\nN - Name" +
                "\nA - Active Status" +
                "\nNt - Notes"+
                "\nChoice(?): ");
            var choice = Console.ReadLine() ?? "";
            
            if(choice.Equals("I", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change ID To (Integer): ");
                client.Id = int.Parse(Console.ReadLine() ?? client.Id.ToString());
            }
            else if(choice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change Name To: ");
                client.Name = Console.ReadLine() ?? client.Name;
            }
            else if(choice.Equals("A", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change Active Status\n1 = True\n0 = False\nStatus?: ");
                client.IsActive = UpdateActive(int.Parse(Console.ReadLine() ??  (Convert.ToInt32(client.IsActive)).ToString()));
            }
            else if(choice.Equals("Nt", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Current Notes: " + client.Notes);
                Console.Write("Change Notes To: ");
                client.Notes = Console.ReadLine() ?? client.Notes;
            }
            else
            {
                Console.WriteLine("ERORR: Invalid Input.");
            }

        }//end of updateClient()

        static void UpdateProject(Project project)
        {
            Console.WriteLine("Property Choice:" +
                "\nI - ID" +
                "\nS - Short Name " +
                "\nL - Long Name " +
                "\nA - Active Status" +
                "\nChoice(?): ");

            var choice = Console.ReadLine() ?? "";
            
            if(choice.Equals("I", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change ID To (Integer): ");
                project.Id = int.Parse(Console.ReadLine() ?? project.Id.ToString());
            }
            else if(choice.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change Short Name To: ");
                project.ShortName = Console.ReadLine() ?? project.ShortName;
            }
            else if (choice.Equals("L", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change Long Name To: ");
                project.LongName = Console.ReadLine() ?? project.LongName;
            }
            else if(choice.Equals("A", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Change Active Status\n1 = True\n0 = False\n Status?: ");
                project.IsActive = UpdateActive(int.Parse(Console.ReadLine() ??  (Convert.ToInt32(project.IsActive)).ToString()));
            }
            else
            {
                Console.WriteLine("ERORR: Invalid Input.");
            }
        }//end of updateProject()

        static Boolean UpdateActive(int status)
        {
            switch (status)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    //Defaults to false 
                    Console.WriteLine("Invalid Input For Active Status. Defaulted To Inactive.");
                    return false;
            }
        }//end of updateActive()

        static void LinkClient(List<Project> projectList, List<Client> clientList)
        {
            //Link A Client to A Project

            //Get Client ID From User
            Console.Write("Enter Client Id: ");
            var chosenClientID = int.Parse(Console.ReadLine() ?? string.Empty);

            //Validate that chosenClientID is found in the clientList
            var clientToLink = clientList.FirstOrDefault(c => c.Id == chosenClientID);

            if (clientToLink != null)
            {
                //Get Project ID From User
                Console.Write("Which Project To Link Client " + chosenClientID + " To?");
                projectList.ForEach(Console.WriteLine);

                Console.Write("Input Project ID: ");
                var chosenProjectID = int.Parse(Console.ReadLine() ?? "");

                //Validate that chosenProjectID is found in the clientList
                var projectToUpdate = projectList.FirstOrDefault(c => c.Id == chosenProjectID);
                if (projectToUpdate != null)
                {
                    //Assign index of projectToUpdate (found in projectList) to projIndex, then update that p 
                    //int projIndex = projectList.IndexOf(projectToUpdate);
                    projectToUpdate.ClientId = chosenClientID;
                    projectToUpdate.linkedClient = clientToLink;
                    projectToUpdate.ClientName = clientToLink.Name;

                }
                else
                {
                    Console.WriteLine("\nERROR: Invalid Project ID.");
                }
            }
            else
            {
                Console.WriteLine("\nERROR: Client ID Not Found.");
            }//end of clientToLink check

        }//end of LinkClient()

    }//end of Program class


}//end of namespace