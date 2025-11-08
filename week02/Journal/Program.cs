using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    
    static void Main(string[] args)
    {
        // Initialize the main journal object and a default filename
        Journal myJournal = new Journal();
        string filename = "my_journal.txt";
        
        int choice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        // Main program loop
        while (choice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            // Input handling
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Write a new entry
                        myJournal.AddEntry();
                        break;

                    case 2:
                        // Display all entries
                        myJournal.DisplayAll();
                        break;

                    case 3:
                        // Load entries from file
                        myJournal.LoadFromFile(filename);
                        break;

                    case 4:
                        // Save entries to file
                        myJournal.SaveToFile(filename);
                        break;

                    case 5:
                        // Quit
                        Console.WriteLine("Thank you for journaling. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}