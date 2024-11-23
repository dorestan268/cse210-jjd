using System;

public class Entry
{
    public string _Prompt;
    public string _Response;
    public string _Date;

    public void Display()
    {
        Console.WriteLine($"Date: {_Date}");
        Console.WriteLine($"Prompt: {_Prompt}");
        Console.WriteLine($"Response: {_Response}");
        Console.WriteLine(new string('-', 40));
    }
}
