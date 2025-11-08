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
                        // 1. Write a new entry
                        myJournal.AddEntry();
                        break;

                    case 2:
                        // 2. Display all entries
                        myJournal.DisplayAll();
                        break;

                    case 3:
                        // 3. Load entries from file
                        myJournal.LoadFromFile(filename);
                        break;

                    case 4:
                        // 4. Save entries to file
                        myJournal.SaveToFile(filename);
                        break;

                    case 5:
                        // 5. Quit
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


/// Represents a single journal entry.
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

   
    /// Displays the entry in a structured format.
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"> {_entryText}");
    }
}

/// Manages a list of Entry objects and handles file operations.
public class Journal
{
    // The list to store all journal entries
    public List<Entry> _entries = new List<Entry>();

    // A list of prompts the program will randomly select from
    private List<string> _prompts = new List<string>
    {
        "If I had one thing I could do over today, what would it be?",
        "What was the best part of my day?",
        "What is one thing I am grateful for today?",
        "What did I learn today?",
        "How did I serve someone else today?"
    };

    private Random _randomGenerator = new Random();

    /// Creates a new entry, prompts the user, and adds it to the journal list.
    public void AddEntry()
    {
        // 1. Select a random prompt
        int index = _randomGenerator.Next(_prompts.Count);
        string prompt = _prompts[index];

        // 2. Get input
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        // 3. Create a new Entry object
        Entry newEntry = new Entry
        {
            _promptText = prompt,
            _entryText = response,
            _date = DateTime.Now.ToShortDateString() // Record the current date
        };

        // 4. Add the entry to the list
        _entries.Add(newEntry);
        Console.WriteLine("Entry saved successfully!");
    }

    /// Iterates through and displays all entries in the journal.
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("--- End of Journal ---");
    }

    /// Saves all current journal entries to a specified file.
    public void SaveToFile(string file)
    {
        try
        {
            // Use a StreamWriter to write to the file
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                }
            }
            Console.WriteLine($"Journal saved successfully to: {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    /// Loads journal entries from a specified file, clearing current entries.
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File not found: {file}");
            return;
        }

        // Clear existing entries before loading new ones
        _entries.Clear(); 
        
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                // Split the line by the delimiter '|'
                string[] parts = line.Split('|');

                if (parts.Length == 3)
                {
                    // Create a new entry from the parts and add it to the list
                    Entry newEntry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2]
                    };
                    _entries.Add(newEntry);
                }
            }
            Console.WriteLine($"Journal loaded successfully from: {file}. {_entries.Count} entries loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}");
        }
    }
}