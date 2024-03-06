using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new JournalEntry(prompt, response, DateTime.Now));
                    break;
                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournal(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournal(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static string GetRandomPrompt()
    {
        // Define a list of prompts
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        // Generate a random index and return the corresponding prompt
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        return prompts[index];
    }
}
//This implementation provides the functionality to write new journal entries,
// display the journal, save the journal to a file, 
// and load the journal from a file. The user interface presents a menu for these options, 
// and each action is performed accordingly. Additionally,
// a random prompt is selected when writing a new entry to provide variety.