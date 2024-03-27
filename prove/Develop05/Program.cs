using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for goals
abstract class Goal
{
    protected string description;
    public int value;

    public Goal(string description, int value)
    {
        this.description = description;
        this.value = value;
    }

    public abstract void RecordEvent();

    public abstract string GetProgress();

    public abstract void LoadGoal(string progress);

    public string Description { get { return description; } }
}

// Simple goal class
class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string description, int value) : base(description, value)
    {
        completed = false;
    }

    public override void RecordEvent()
    {
        completed = true;
    }

    public override string GetProgress()
    {
        return completed ? "[X]" : "[ ]";
    }

    public override void LoadGoal(string progress)
    {
        completed = progress == "[X]";
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    private int timesCompleted;

    public EternalGoal(string description, int value) : base(description, value)
    {
        timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        timesCompleted++;
    }

    public override string GetProgress()
    {
        return timesCompleted + " time(s)";
    }

    public override void LoadGoal(string progress)
    {
        timesCompleted = int.Parse(progress.Split(' ')[0]);
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    private int totalTimes;
    private int timesCompleted;

    public ChecklistGoal(string description, int value, int totalTimes) : base(description, value)
    {
        this.totalTimes = totalTimes;
        timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        timesCompleted++;
    }

    public override string GetProgress()
    {
        return "Completed " + timesCompleted + "/" + totalTimes + " times";
    }

    public override void LoadGoal(string progress)
    {
        int timesCompleted = 0;

        // Split the progress string by space (' ') character
        string[] progressParts = progress.Split(' ');

        // Check if the progress string has at least two parts
        if (progressParts.Length >= 2)
        {
            // Extract the part containing the number of times completed
            string[] completionParts = progressParts[1].Split('/');

            // Check if the completion parts array has at least one element
            if (completionParts.Length >= 1)
            {
                // Parse the number of times completed
                if (int.TryParse(completionParts[0], out timesCompleted))
                {
                    // Successfully parsed the number of times completed
                    Console.WriteLine("Number of times completed: " + timesCompleted);
                }
                else
                {
                    // Failed to parse the number of times completed
                    Console.WriteLine("Failed to parse the number of times completed.");
                }
            }
            else
            {
                // The completion parts array is empty
                Console.WriteLine("Completion parts array is empty.");
            }
        }
        else
        {
            // The progress string does not contain enough parts
            Console.WriteLine("Progress string does not contain enough parts.");
        }

    }
}

// Main program
class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        LoadGoals();
        DisplayMenu();
    }

    static void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save and Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ViewGoals();
                    break;
                case 2:
                    CreateNewGoal();
                    break;
                case 3:
                    RecordEvent();
                    break;
                case 4:
                    ViewScore();
                    break;
                case 5:
                    SaveAndExit();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void ViewGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("Current Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.Description + " - " + goal.GetProgress());
        }
    }

    static void CreateNewGoal()
    {
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter goal value: ");
        int value = int.Parse(Console.ReadLine());

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (choice)
        {
            case 1:
                goal = new SimpleGoal(description, value);
                break;
            case 2:
                goal = new EternalGoal(description, value);
                break;
            case 3:
                Console.Write("Enter total times for the checklist goal: ");
                int totalTimes = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(description, value, totalTimes);
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("New goal created successfully.");
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("Select a goal to record event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + goals[i].Description);
        }

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        goals[choice].RecordEvent();
        score += goals[choice].value;

        Console.WriteLine("Event recorded successfully.");
    }

    static void ViewScore()
    {
        Console.WriteLine("Current Score: " + score);
    }

    static void SaveAndExit()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.GetType().Name + "," + goal.Description + "," + goal.GetProgress());
            }
        }

        Console.WriteLine("Goals saved successfully. Exiting program.");
        Environment.Exit(0);
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string type = parts[0];
                    string description = parts[1];
                    string progress = parts[2];

                    Goal goal = null;

                    switch (type)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(description, 0);
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(description, 0);
                            break;
                        case "ChecklistGoal":
                            goal = new ChecklistGoal(description, 0, 0);
                            break;
                    }

                    goal.LoadGoal(progress);
                    goals.Add(goal);
                }
            }
        }
    }
}
