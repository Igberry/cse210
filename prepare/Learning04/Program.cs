// Program.cs (Main method)
using System;

class Program
{
    static void Main(string[] args)
    {
        // Testing MathAssignment
        MathAssignment mathAssignment = new MathAssignment("David Chukwudi Igberi", "Linear Equation", "Chapter 2", "5-10, 15-20");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Testing WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Carter Eric", "Essay", "Write About the Importance of Education in your Life");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}