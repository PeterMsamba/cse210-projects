using System;
using System.Threading;
using System.Collections.Generic;
// Additional code for creativity is "Keeping a log of how many times activities were performed"
public class Program
{
    public static void DisplayMenu()
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("**Mindfulness Activity Program**");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Please choose an activity to begin:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit and View Log");
        Console.WriteLine(new string('-', 50));
    }

    public static void DisplayLog()
    {
        Console.WriteLine("\n" + new string('*', 50));
        Console.WriteLine("** Activity Session Log **");
        Console.WriteLine(new string('*', 50));

        // Access the static log defined in the Activity base class
        Dictionary<string, int> log = Activity.ActivityLog; 
        
        if (log.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            foreach (var kvp in log)
            {
                Console.WriteLine($"- **{kvp.Key} Activity** completed: **{kvp.Value}** time(s).");
            }
        }
        Console.WriteLine(new string('*', 50));
    }

    public static void Main(string[] args)
    {
        // Use the activity classes defined in separate files
        Dictionary<string, Activity> activities = new Dictionary<string, Activity>
        {
            {"1", new BreathingActivity()},
            {"2", new ReflectionActivity()},
            {"3", new ListingActivity()}
        };

        while (true)
        {
            DisplayMenu();
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine()?.Trim();

            if (choice == "4")
            {
                DisplayLog(); // Show the log on exit
                Console.WriteLine("\nThank you for taking time for yourself. Goodbye!");
                return;
            }
            else if (activities.ContainsKey(choice))
            {
                try
                {
                    activities[choice].Run(); // Polymorphism
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during the activity: {ex.Message}");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.");
                Thread.Sleep(2000);
            }
        }
    }
}