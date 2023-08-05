//Nathan Wallen
//
//Client.cs

//Usage: Client Class that holds 
using System;

namespace PracticeManagement.Library.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime CloseDate { get; set; }
    public Boolean IsActive { get; set; }

    public Client()
    {
        OpenDate = DateTime.Today;
        CloseDate = DateTime.Today.AddDays(365);
    }


    //Override the Object.ToString() function.
    //This allows us to format the output when a Client class is parsed as a string (i.e. when passed in Console.WriteLine())
    //Can do this because ToString() is a virtual function on the Object Class that our Client is derived from.
    public override string ToString()
    {
        return $"-{Name}\n";
                /*$"\n////////////////////////\nID:{Id} \nName:{Name} \nStart Date: {OpenDate} \nClose Date: {CloseDate}" +
            $"\nActive(?): {IsActive}\nNotes: {Notes}\n////////////////////////";*/
    }//end of ToString() override

}//end of class
