using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Activity Program!");

        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PerformBreathingActivity();
                    break;
                case 2:
                    PerformReflectionActivity();
                    break;
                case 3:
                    PerformListingActivity();
                    break;
                case 4:
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void PerformBreathingActivity()
    {
        BreathingActivity breathingActivity = new BreathingActivity("Breathing", "Relax by breathing in and out slowly.");
        breathingActivity.Start();
        breathingActivity.PerformBreathing();
        breathingActivity.End();
    }

    static void PerformReflectionActivity()
    {
        ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "Reflect on times when you've shown strength and resilience.");
        reflectionActivity.Start();
        reflectionActivity.PerformReflection();
        reflectionActivity.End();
    }

    static void PerformListingActivity()
    {
        ListingActivity listingActivity = new ListingActivity("Listing", "Reflect on the good things in your life by listing items.");
        listingActivity.Start();
        listingActivity.PerformListing();
        listingActivity.End();
    }
}
