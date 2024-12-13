using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_name} Activity...");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
        PerformActivity(duration);
        EndActivity(duration);
    }

    protected abstract void PerformActivity(int duration);

    private void EndActivity(int duration)
    {
        Console.WriteLine("Great job! You've completed the activity.");
        Console.WriteLine($"Activity: {_name}, Duration: {duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = seconds; i > 0 ; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void BreathingAnimation(int seconds)
    {
        for (int i = seconds; i > 0 ; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
