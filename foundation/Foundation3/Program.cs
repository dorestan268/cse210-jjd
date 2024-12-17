using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
       
        Console.WriteLine("-----Fitness Activity Report-----");
        Console.WriteLine();
        

        var activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2024, 12, 1), 45, 5.0),
            new CyclingActivity(new DateTime(2024, 12, 5), 35, 12.0), 
            new SwimmingActivity(new DateTime(2024, 12, 10), 25, 40)  
        };

    
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
