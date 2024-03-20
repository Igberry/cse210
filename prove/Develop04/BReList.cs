using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    protected override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    public void PerformBreathing()
    {
        int timeRemaining = _duration;
        while (timeRemaining > 0)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(3000); // Pause for 3 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(3000); // Pause for 3 seconds
            timeRemaining -= 6; // Each cycle takes 6 seconds (3 seconds inhale + 3 seconds exhale)
        }
    }
}

public class ReflectionActivity : Activity
{
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string name, string description) : base(name, description)
    {
    }

    protected override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    public void PerformReflection()
    {
        Random random = new Random();
        foreach (string prompt in _prompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(3000); // Pause for 3 seconds
            foreach (string question in _questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(3000); // Pause for 3 seconds
            }
        }
    }
}

public class ListingActivity : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description) : base(name, description)
    {
    }

    protected override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    public void PerformListing()
    {
        Random random = new Random();
        Console.WriteLine("Prompt: " + _prompts[random.Next(_prompts.Length)]);
        Console.WriteLine("You have a few seconds to begin thinking...");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.WriteLine("Go ahead and start listing items:");
        Thread.Sleep(_duration * 1000); // Pause for the specified duration
        Console.WriteLine($"You listed {_duration / 2} items.");
    }
}
