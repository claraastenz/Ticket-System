using System;
using System.IO;

namespace TicketManagementApp
{
    public class Ticket
{
    public int TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }

    public override string ToString()
    {
        return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}";
    }
}

public class TicketFile
{
    private string filePath;

    public TicketFile(string filePath)
    {
        this.filePath = filePath;
    }

    public void ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    public void CreateFileFromData()
    {
        
    }
}
   public class Program
{
    static void Main(string[] args)
    {
        string file = "Tickets.csv";
        string choice;
        TicketFile ticketFile = new TicketFile(file);

        do
        {
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("Enter any other key to exit.");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                ticketFile.ReadFromFile();
            }
            else if (choice == "2")
            {
                ticketFile.CreateFileFromData();
            }

        } while (choice == "1" || choice == "2");
    }
                
                   
        
    }
}
