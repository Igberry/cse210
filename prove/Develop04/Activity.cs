using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        DisplayStartingMessage();
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public void End()
    {
        DisplayEndingMessage();
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity:");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Congratulations! You've completed the {_name} Activity.");
        Console.WriteLine($"Duration: {_duration} seconds.");
    }
}
