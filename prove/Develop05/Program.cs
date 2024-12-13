using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    private static Dictionary<string, int> activityLog = new Dictionary<string, int>();

    public static void Main(string[] args)
    {
        LoadLog();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                "4" => new GratitudeActivity(),
                "5" => null,
                _ => throw new InvalidOperationException("Invalid option. Try again.")
            };

            if (activity == null)
                break;

            Console.Clear();
            activity.StartActivity();
            LogActivity(activity);
        }

        SaveLog();
        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }

    private static void LogActivity(Activity activity)
    {
        string activityName = activity.GetType().Name;
        if (activityLog.ContainsKey(activityName))
        {
            activityLog[activityName]++;
        }
        else
        {
            activityLog[activityName] = 1;
        }
    }

    private static void SaveLog()
    {
        using StreamWriter file = new StreamWriter("activityLog.txt");
        foreach (var entry in activityLog)
        {
            file.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    private static void LoadLog()
    {
        if (File.Exists("activityLog.txt"))
        {
            using StreamReader file = new StreamReader("activityLog.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(": ");
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    activityLog[parts[0]] = count;
                }
            }
        }
    }
}
