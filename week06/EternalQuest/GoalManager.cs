using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalNames()
    {
        // Used primarily for the "Record Event" menu
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        
        Console.Write("Which goal did you accomplish? ");
        // Subtract 1 because list is 0-indexed but display is 1-indexed
        int index = int.Parse(Console.ReadLine()) - 1; 

        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else 
        {
            Console.WriteLine("Invalid goal selected.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // First line is the score
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            
            // First line is the score
            _score = int.Parse(lines[0]);

            // Clear existing goals to avoid duplicates
            _goals.Clear(); 

            // Skip the first line
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string details = parts[1];
                string[] paramsArr = details.Split(",");

                if (goalType == "SimpleGoal")
                {
                    // name, desc, points, isComplete
                    SimpleGoal newGoal = new SimpleGoal(paramsArr[0], paramsArr[1], paramsArr[2]);
                    newGoal.SetComplete(bool.Parse(paramsArr[3]));
                    _goals.Add(newGoal);
                }
                else if (goalType == "EternalGoal")
                {
                    // name, desc, points
                    EternalGoal newGoal = new EternalGoal(paramsArr[0], paramsArr[1], paramsArr[2]);
                    _goals.Add(newGoal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    // name, desc, points, bonus, target, amountCompleted
                    ChecklistGoal newGoal = new ChecklistGoal(paramsArr[0], paramsArr[1], paramsArr[2], int.Parse(paramsArr[4]), int.Parse(paramsArr[3]));
                    newGoal.SetAmountCompleted(int.Parse(paramsArr[5]));
                    _goals.Add(newGoal);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}