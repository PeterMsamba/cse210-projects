using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

// --- Base Activity Class ---
// To show creativity i added "Keeping a log of how many times activities were performed."

public abstract class Activity
{
    // --- Static Tracking Mechanism (Creative Addition) ---
    // A shared dictionary to log the count of times each activity name is run.
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    // Private members for encapsulation
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Static property to expose the log (read-only access)
    public static Dictionary<string, int> ActivityLog => _activityLog;

    // --- Common Utility Methods (Unchanged) ---

    protected void ShowSpinner(int seconds)
    {
        char[] symbols = { '|', '/', '-', '\\' };
        Console.Write("Pausing...");
        
        long endTime = DateTimeOffset.Now.ToUnixTimeSeconds() + seconds;
        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            foreach (char symbol in symbols)
            {
                Console.Write($"\rPausing... {symbol}"); 
                Thread.Sleep(100);
            }
        }
        Console.Write($"\r{" ", 20}\r"); 
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rTime remaining: {i} seconds ");
            Thread.Sleep(1000);
        }
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

    // --- Common Start and End Messages ---

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
        
        // --- LOGGING UPDATE ---
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

// --- Derived Activity Classes (Logic Unchanged) ---

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }

    protected override void ExecuteActivity()
    {
        long startTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        long endTime = startTime + _duration;

        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            long remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            if (remaining <= 0) break;

            Console.WriteLine("Breathe in...");
            int pauseIn = (int)Math.Min(3, remaining);
            if (pauseIn > 0) { ShowCountdown(pauseIn); }
            
            remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            if (remaining <= 0) break;

            Console.WriteLine("Breathe out...");
            int pauseOut = (int)Math.Min(4, remaining);
            if (pauseOut > 0) { ShowCountdown(pauseOut); }
        }
    }
}

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?", "Have you ever done anything like this before?", 
        "How did you get started?", "How did you feel when it was complete?", 
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?",
    };

    private Random _random = new Random();

    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    ) { }

    protected override void ExecuteActivity()
    {
        string mainPrompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n**Main Prompt:** {mainPrompt}");
        Console.WriteLine("Take a moment to recall the experience...");
        ShowSpinner(5);

        long endTime = DateTimeOffset.Now.ToUnixTimeSeconds() + _duration;
        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            string question = _questions[_random.Next(_questions.Count)];
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"**Question for Reflection:** {question}");

            long remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            int pauseTime = (int)Math.Min(10, remaining);

            if (pauseTime > 0)
            {
                ShowSpinner(pauseTime);
            }
            else
            {
                break;
            }
        }
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?", "What are personal strengths of yours?", 
        "Who are people that you have helped this week?", "When have you felt gratitude this month?", 
        "Who are some of your personal heroes?",
    };

    private Random _random = new Random();

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) { }

    protected override void ExecuteActivity()
    {
        string mainPrompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n**Main Prompt:** {mainPrompt}");

        Console.WriteLine("You have 5 seconds to begin thinking about your list...");
        ShowCountdown(5);

        Console.WriteLine("\n**Start Listing!** Enter one item at a time. Press Enter after each item.");
        Console.WriteLine($"You have {_duration} seconds.");

        long startTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        long endTime = startTime + _duration;
        int item_count = 0;
        
        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            long remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            if (remaining <= 0) break;

            Console.Write($"Item {item_count + 1} (Time left: {remaining}s): ");
            string input = Console.ReadLine(); 

            if (input != null && input.Trim().Length > 0)
            {
                item_count++;
            }
        }
        
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"**Time's up!** You listed **{item_count}** items in {_duration} seconds.");
    }
}

// --- Program Entry Point ---

public class Program
{
    public static void DisplayMenu()
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("🧘 **Mindfulness Activity Program** 🧘");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Please choose an activity to begin:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit and View Log"); // Updated option name
        Console.WriteLine(new string('-', 50));
    }

    // --- NEW METHOD ---
    public static void DisplayLog()
    {
        Console.WriteLine("\n" + new string('*', 50));
        Console.WriteLine("** Activity Session Log **");
        Console.WriteLine(new string('*', 50));

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
                    activities[choice].Run();
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