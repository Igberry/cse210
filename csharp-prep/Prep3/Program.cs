using System;

class Program
{
    static void Main(string[] args)
    {
        // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        int guess;
        int guessCount = 0;
        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I've picked a number between 1 and 100. Try to guess it!");

            // Reset guess count for each game
            guessCount = 0;

            // Loop until the user guesses the magic number
            do
            {
                // Ask the user for a guess
                Console.Write("Enter your guess: ");
                guess = Convert.ToInt32(Console.ReadLine());

                // Check if the guess is higher, lower, or correct
                if (guess < magicNumber)
                {
                    Console.WriteLine("Too low! Guess higher.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Too high! Guess lower.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You've guessed the magic number {magicNumber}!");
                }

                guessCount++;

            } while (guess != magicNumber);

            // Inform the user of the number of guesses made
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();

            // Check if the user wants to play again
            if (playAgainResponse != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thank you for playing Guess My Number!");
            }
        }
    }
}
