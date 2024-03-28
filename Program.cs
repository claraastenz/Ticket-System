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

    public class Enhancement : Ticket
    {
        public string Software { get; set; }
        public double Cost { get; set; }
        public string Reason { get; set; }
        public TimeSpan Estimate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()},{Software},{Cost},{Reason},{Estimate}";
        }
    }

    public class Task : Ticket
    {
        public string ProjectName { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()},{ProjectName},{DueDate}";
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
            catch (Exception ex)
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
            string choice;
            do
            {
                Console.WriteLine("1) Read data from Tickets.csv.");
                Console.WriteLine("2) Read data from Enhancements.csv.");
                Console.WriteLine("3) Read data from Tasks.csv.");
                Console.WriteLine("4) Create file from data.");
                Console.WriteLine("Press Enter to exit.");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            TicketFile ticketsFile = new TicketFile("Tickets.csv");
                            ticketsFile.ReadFromFile();
                            break;
                        }
                    case "2":
                        {
                            TicketFile enhancementsFile = new TicketFile("Enhancements.csv");
                            enhancementsFile.ReadFromFile();
                            break;
                        }
                    case "3":
                        {
                            TicketFile tasksFile = new TicketFile("Task.csv");
                            tasksFile.ReadFromFile();
                            break;
                        }
                    case "4":
                        {
                            TicketFile ticketsFile = new TicketFile("Tickets.csv");
                            ticketsFile.CreateFileFromData();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            } while (!string.IsNullOrEmpty(choice));
        }
    }
}
