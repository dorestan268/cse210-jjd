using System;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Basics", "Code Academy", 600);
        Video video2 = new Video("Introduction to OOP", "Learn Programming", 1200);
        Video video3 = new Video("Advanced C# Features", "Tech Guru", 1800);

        // Add comments to videos
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This helped me a lot."));
        video1.AddComment(new Comment("Charlie", "Thanks for the video!"));

        video2.AddComment(new Comment("Diana", "Very detailed."));
        video2.AddComment(new Comment("Evan", "Loved the examples."));
        video2.AddComment(new Comment("Frank", "Easy to follow."));

        video3.AddComment(new Comment("Grace", "Excellent content."));
        video3.AddComment(new Comment("Hank", "Looking forward to more."));
        video3.AddComment(new Comment("Ivy", "The pace is perfect."));

        // Store videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (var video in videos)
        {
            video.DisplayDetails();
        }
    }
}
