// Assignment.cs
using System;

public class Assignment
{
    // Private member variables
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return a summary of the assignment
    public virtual string GetSummary()
    {
        return $"Student Name: {_studentName}\nTopic: {_topic}";
    }
}
