using System;
using System.Threading;
using System.Collections.Generic;

// To show creativity i added "Keeping a log of how many times activities were performed."

public abstract class Activity
{
    // --- Static Tracking Mechanism (Creative Addition) ---
    // A shared dictionary to log the count of times each activity name is run.
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    // Private members for encapsulation
    private string _name;
    private string _description;
    protected int _duration; // Protected for direct access by derived classes

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Static property to expose the log (read-only access)
    public static Dictionary<string, int> ActivityLog => _activityLog;

    // --- Common Utility Methods ---

    protected void ShowSpinner(int seconds)
    {
        char[] symbols = { '|', '/', '-', '\\' };
        Console.Write("Pausing...");
        
        long endTime = DateTimeOffset.Now.ToUnixTimeSeconds() + seconds;
        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            foreach (char symbol in symbols)
            {
                // Uses \r to create the spinning effect
                Console.Write($"\rPausing... {symbol}"); 
                Thread.Sleep(100);
            }
        }
        // Clear the spinner line
        Console.Write($"\r{" ", 20}\r"); 
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // Uses \r to create the countdown effect
            Console.Write($"\rTime remaining: {i} seconds ");
            Thread.Sleep(1000);
        }
        // Clear the countdown line
        Console.Write($"\r{" ", 30}\r");
    }

    private void GetDuration()
    {
        while (true)
        {
            Console.Write("Please enter the duration of the activity in seconds (e.g., 30): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int duration) && duration > 0)
            {
                _duration = duration;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive whole number.");
            }
        }
    }

    // --- Common Start and End Messages (Shared Behavior) ---

    private void ShowStartingMessage()
    {
        Console.WriteLine("\n" + new string('-', 50));
        Console.WriteLine($"**Starting: {_name} Activity**");
        Console.WriteLine($"Description: {_description}");
        GetDuration();
        Console.WriteLine($"\nDuration set to {_duration} seconds.");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    private void ShowEndingMessage()
    {
        Console.WriteLine("\n" + new string('-', 50));
        Console.WriteLine("**Congratulations!** You've done a good job!");
        ShowSpinner(2);
        Console.WriteLine($"You completed the **{_name}** activity, which lasted for {_duration} seconds.");
        
        // --- LOGGING UPDATE (Creative Addition) ---
        // Increment the log count for this activity
        if (_activityLog.ContainsKey(_name))
        {
            _activityLog[_name]++;
        }
        else
        {
            _activityLog.Add(_name, 1);
        }
        
        ShowSpinner(3);
        Console.WriteLine(new string('-', 50));
    }

    // --- Template Method and Abstract Method ---

    public void Run()
    {
        ShowStartingMessage();
        ExecuteActivity();
        ShowEndingMessage();
    }

    protected abstract void ExecuteActivity();
}