using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = new List<double>();

        Console.WriteLine("Enter a series of numbers (enter 0 to stop):");

        // Loop to input numbers
        while (true)
        {
            double number = Convert.ToDouble(Console.ReadLine());

            // Check if the number is 0 to stop the loop
            if (number == 0)
                break;

            numbers.Add(number);
        }

        if (numbers.Count > 0)
        {
            // Core Requirements

            // Compute the sum of the numbers
            double sum = numbers.Sum();

            // Compute the average of the numbers
            double average = numbers.Average();

            // Find the maximum number in the list
            double max = numbers.Max();

            Console.WriteLine($"Sum of the numbers: {sum}");
            Console.WriteLine($"Average of the numbers: {average}");
            Console.WriteLine($"Maximum number: {max}");

            // Stretch Challenge

            // Find the smallest positive number
            double smallestPositive = numbers.Where(x => x > 0).DefaultIfEmpty(double.NaN).Min();
            Console.WriteLine($"Smallest positive number: {(double.IsNaN(smallestPositive) ? "No positive numbers" : smallestPositive.ToString())}");

            // Sort the numbers and display the sorted list
            List<double> sortedNumbers = numbers.OrderBy(x => x).ToList();
            Console.WriteLine("Sorted numbers:");
            foreach (var num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers entered!");
        }
    }
}
