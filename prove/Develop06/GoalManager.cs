using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private static GoalManager _instance;
    private List<Goal> _goals;
    private int _score;

    private const string FilePath = "goals.txt"; 

    private GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public static GoalManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GoalManager();
            }
            return _instance;
        }
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals and score saved successfully.");
    }

    private void LoadGoals()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        _goals.Clear(); 
        using (StreamReader reader = new StreamReader(FilePath))
        {
            _score = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                if (type == "SimpleGoal")
                {
                    string name = details[0];
                    string description = details[1];
                    int points = int.Parse(details[2]);
                    bool isComplete = bool.Parse(details[3]);
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    if (isComplete) goal.RecordEvent();
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    string name = details[0];
                    string description = details[1];
                    int points = int.Parse(details[2]);
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = details[0];
                    string description = details[1];
                    int points = int.Parse(details[2]);
                    int target = int.Parse(details[3]);
                    int bonus = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    for (int i = 0; i < amountCompleted; i++) goal.RecordEvent();
                    _goals.Add(goal);
                }
                else if (type == "Creativity")
                {
                    string name = details[0];
                    string description = details[1];
                    int points = int.Parse(details[2]);
                    string creativeTask = details[3];
                    bool isComplete = bool.Parse(details[4]);
                    DateTime completionDate = DateTime.Parse(details[5]);
                    Creativity goal = new Creativity(name, description, points, creativeTask);
                    if (isComplete) 
                    {
                        goal.RecordEvent(); 
                    }
                    _goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals and score loaded successfully.");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event for:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string completionStatus = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {completionStatus} {_goals[i].GetDetailsString()}");
        }

        if (int.TryParse(Console.ReadLine(), out int goalIndex) &&
            goalIndex > 0 && goalIndex <= _goals.Count)
        {
            _goals[goalIndex - 1].RecordEvent();

            if (_goals[goalIndex - 1].IsComplete())
            {
                Console.WriteLine("Goal Completed!");

                if (_goals[goalIndex - 1] is ChecklistGoal checklistGoal)
                {
                    _score += checklistGoal.Points + checklistGoal.Bonus;
                }
                else if (_goals[goalIndex - 1] is Creativity creativityGoal)
                {
                    _score += creativityGoal.Points;
                }
                else
                {
                    _score += _goals[goalIndex - 1].Points;
                }
            }
            else
            {
                _score += _goals[goalIndex - 1].Points;
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine($"\nCurrent Score: {_score}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1. Simple  2. Eternal  3. Checklist  4. Creativity");
        string type = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                Console.Write("Enter the creative task (e.g., generate new ideas, solve a problem): ");
                string creativeTask = Console.ReadLine();
                _goals.Add(new Creativity(name, description, points, creativeTask));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}
