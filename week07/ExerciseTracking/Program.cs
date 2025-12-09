using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fitness Activity Tracker");

        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Create a Running Activity
        Running run1 = new Running(
            new DateTime(2025, 12, 08), // Date
            30,                          // Duration in minutes
            4.8                            // Distance in km
        );
        activities.Add(run1);

        // Create a Cycling Activity
        Cycling cycle1 = new Cycling(
            new DateTime(2025, 12, 09), // Date
            45,                          // Duration in minutes
            25.0                         // Speed in kph
        );
        activities.Add(cycle1);

        // Create a Swimming Activity
        Swimming swim1 = new Swimming(
            new DateTime(2025, 12, 09), // Date
            20,                          // Duration in minutes
            10                           // Number of laps (1 lap = 50m)
        );
        activities.Add(swim1);

        // Create another example for completeness
        Running run2 = new Running(
            new DateTime(2025, 12, 10), // Date
            60,                          // Duration in minutes
            10.0                         // Distance in km
        );
        activities.Add(run2);


        Console.WriteLine("Summary of Recorded Activities (Calculations in km/kph/min per km):");

        // Iterate through the list and call GetSummary() on each item.
        foreach (Activity activity in activities)
        {
            // Call the GetSummary method defined in the base class
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }

        Console.WriteLine("Program finished.");
    }
}