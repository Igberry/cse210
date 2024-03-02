using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = Convert.ToInt32(Console.ReadLine());

        // Determine the letter grade
        string letter;
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine if the user passed the course
        string passStatus;
        if (gradePercentage >= 70)
        {
            passStatus = "Congratulations! You passed the course.";
        }
        else
        {
            passStatus = "You did not pass the course. Better luck next time!";
        }

        // Display the letter grade and pass/fail message
        Console.WriteLine($"Your letter grade is {letter}.");
        Console.WriteLine(passStatus);

        // Determine the sign (+, -, or none)
        string sign = "";
        int lastDigit = gradePercentage % 10;
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3 && letter != "F")
        {
            sign = "-";
        }

        // Handle exceptional cases of A+, A-, F+, and F-
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        else if (letter == "F" && (sign == "+" || sign == "-"))
        {
            sign = "";
        }

        // Display the letter grade with sign
        Console.WriteLine($"Your letter grade with sign is {letter}{sign}.");
    }
}
