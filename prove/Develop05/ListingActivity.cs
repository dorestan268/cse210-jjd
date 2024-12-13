using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _remainingPrompts;

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _remainingPrompts = new List<string>(Prompts);
    }

    protected override void PerformActivity(int duration)
    {
        Random random = new();
        if (_remainingPrompts.Count == 0)
        {
            _remainingPrompts = new List<string>(Prompts);
        }
        Console.WriteLine(_remainingPrompts[random.Next(_remainingPrompts.Count)]);
        _remainingPrompts.RemoveAt(random.Next(_remainingPrompts.Count));
        PauseWithAnimation(3);

        Console.WriteLine("Start listing items:");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> items = new();

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"You listed {items.Count} items. Well done!");
    }
}
