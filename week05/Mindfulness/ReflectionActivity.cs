using System;
using System.Collections.Generic;

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
        // Randomly select and display the main prompt
        string mainPrompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n**Main Prompt:** {mainPrompt}");
        Console.WriteLine("Take a moment to recall the experience...");
        ShowSpinner(5);

        long endTime = DateTimeOffset.Now.ToUnixTimeSeconds() + _duration;
        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            // Randomly select and display a reflection question
            string question = _questions[_random.Next(_questions.Count)];
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"**Question for Reflection:** {question}");

            long remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            int pauseTime = (int)Math.Min(10, remaining); // Pause up to 10 seconds

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