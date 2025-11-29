using System;
using System.Collections.Generic;

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
        // Randomly select and display the main prompt
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
            // ReadLine() blocks, consuming the remaining time.
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