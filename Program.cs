using System;
using System.IO;

namespace TicketManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;

            do
            {
                // Ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                // Input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Read data from file
                    if (File.Exists(file))
                    {
                        // Read and display data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // Create file from data
                    StreamWriter sw = new StreamWriter(file, append: true);

                    do
                    {
                        // Ask questions for Ticket data
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

                        // Write Ticket data to file
                        sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}");

                        // Ask if user wants to add another ticket
                        Console.WriteLine("Do you want to add another ticket? (Y/N)");
                        choice = Console.ReadLine().ToUpper();

                    } while (choice == "Y");

                    sw.Close();
                }

            } while (choice == "1" || choice == "2");
        }
    }
}
