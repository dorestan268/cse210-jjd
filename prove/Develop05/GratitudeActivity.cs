using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "What are you grateful for today?",
        "Think of a person who has positively impacted your life.",
        "What is something good that happened to you recently?",
        "What skill or talent do you have that you are thankful for?"
    };

    private List<string> _remainingPrompts;

    public GratitudeActivity() : base(
        "Gratitude",
        "This activity will help you reflect on things you are grateful for in your life.")
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

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine("Take a moment to think about this.");
            PauseWithAnimation(5);
            elapsed += 5;
        }
    }
}
