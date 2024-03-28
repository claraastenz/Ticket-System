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
    public string Severity { get; set; }

    public override string ToString()
    {
        return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching},{Severity}";
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
        try
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
    catch(Exception ex )
    {
        Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
    }
    }

    public void CreateFileFromData()
    {
        using (StreamWriter sw = new StreamWriter(filePath, append: true))
        {
            string choice;
            do
            {
                Console.WriteLine("Enter TicketID:");
                int ticketID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Summary:");
                string summary = Console.ReadLine();

                Console.WriteLine("Enter Status:");
                string status = Console.ReadLine();

                Console.WriteLine("Enter Priority:");
                string priority = Console.ReadLine();

                Console.WriteLine("Enter Submitter:");
                string submitter = Console.ReadLine();

                Console.WriteLine("Enter Assigned:");
                string assigned = Console.ReadLine();

                Console.WriteLine("Enter Watching (separate names with commas):");
                string watching = Console.ReadLine();

                Console.WriteLine("Enter Severity:");
                string severity = Console.ReadLine();

                sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching},{severity}");

                Console.WriteLine("Do you want to add another ticket? (Y/N)");
                choice = Console.ReadLine().ToUpper();
            } while (choice == "Y");
        }
        
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
