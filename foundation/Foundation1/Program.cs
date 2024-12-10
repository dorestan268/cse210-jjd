using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video {Title = "Python Basics", Author = "Jean Junior DORESTAN", LengthInSeconds = 600};
        var video2 = new Video {Title = "Introduction to HTML", Author = "Dave Thedy", LengthInSeconds = 1200};
        var video3 = new Video {Title = "Advanced C# Features", Author = "Rafter K. Joly", LengthInSeconds = 1800};

        // Add comments to videos
        video1.AddSuggestion(new Suggestion("Emma", "Great explanation!"));
        video1.AddSuggestion(new Suggestion("Noel", "This helped me a lot."));
        video1.AddSuggestion(new Suggestion("Ricardo", "Thanks for the video!"));

        video2.AddSuggestion(new Suggestion("Paul", "Very detailed."));
        video2.AddSuggestion(new Suggestion("Blanc", "Loved the examples."));
        video2.AddSuggestion(new Suggestion("Louissaint", "Easy to follow."));

        video3.AddSuggestion(new Suggestion("Dyno", "Excellent content."));
        video3.AddSuggestion(new Suggestion("Emmanuela", "Very explicit."));
        video3.AddSuggestion(new Suggestion("Keemy", "I need more content like that."));

        // Store videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Suggestions: {video.GetSuggestionCount()}");

            foreach (var suggestion in video.GetSuggestions())
            {
                Console.WriteLine($"- {suggestion.Name}: {suggestion.Text}");
            }

            Console.WriteLine();
        }
    }
}
