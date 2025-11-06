using System;
using System.Collections.Generic;

// The main class that contains the program entry point
class Program
{
    static void Main(string[] args)
    {
        // Creating and setting up the first Job instance
        Job job1 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Microsoft",
            _startYear = 2019,
            _endYear = 2022
        };

        // Creating second Job instance
        Job job2 = new Job
        {
            _jobTitle = "Manager",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        // Creatting a new Resume instance
        Resume myResume = new Resume
        {
            _name = "Peter Msamba"
        };

        // Add the job instances to the Resume's list of jobs
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Displaying the whole resume
        myResume.Display();
    }
}

// Class Definitions Start Here

public class Job
{
    // Responsibilities: Member Variables
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

// Resume Class
public class Resume
{
    // Responsibilities: Member Variables
    public string _name;
    
    // Initialize the list of Jobs
    public List<Job> _jobs = new List<Job>(); 

    /// Displays the person's name followed by the details of each job in the list.
    public void Display()
    {
        Console.WriteLine($"\nName: {_name}");
        Console.WriteLine("Jobs:");

        // Iterate through each job and call its Display method
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}