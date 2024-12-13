using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _remainingPrompts;
    private List<string> _remainingQuestions;

    public ReflectingActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _remainingPrompts = new List<string>(Prompts);
        _remainingQuestions = new List<string>(Questions);
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
            if (_remainingQuestions.Count == 0)
            {
                _remainingQuestions = new List<string>(Questions);
            }
            Console.WriteLine(_remainingQuestions[random.Next(_remainingQuestions.Count)]);
            _remainingQuestions.RemoveAt(random.Next(_remainingQuestions.Count));
            PauseWithAnimation(5);
            elapsed += 5;
        }
    }
}
