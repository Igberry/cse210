using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Introduction to C#", "Carter Eric", 300);
        Video video2 = new Video("Advanced C# Programming", "David C. Igberi", 450);
        Video video3 = new Video("C# Object-Oriented Programming", "Deborah Igberi", 600);

        // Add comments to videos
        video1.Comments.Add(new Comment("User1", "Great tutorial!"));
        video1.Comments.Add(new Comment("User2", "Very helpful, thanks!"));

        video2.Comments.Add(new Comment("User3", "This video is awesome!"));
        video2.Comments.Add(new Comment("User4", "I learned a lot from this."));

        video3.Comments.Add(new Comment("User5", "Excellent explanation!"));
        video3.Comments.Add(new Comment("User6", "Keep up the good work!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information about each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
