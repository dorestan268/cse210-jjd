using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _Entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string date)
    {
        _Entries.Add(new Entry { _Prompt = prompt, _Response = response, _Date = date });
    }

    public void DisplayEntries()
    {
        if (_Entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        foreach (var entry in _Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _Entries)
            {
                string escapedPrompt = entry._Prompt.Replace("\"", "\"\"");
                string escapedResponse = entry._Response.Replace("\"", "\"\"");
                writer.WriteLine($"\"{escapedPrompt}\",\"{escapedResponse}\",\"{entry._Date}\"");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} does not exist.");
            return;
        }

        _Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split("\",\"");
            if (parts.Length == 3)
            {
                string prompt = parts[0].Trim('"');
                string response = parts[1].Trim('"');
                string date = parts[2].Trim('"');
                _Entries.Add(new Entry { _Prompt = prompt, _Response = response, _Date = date });
            }
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }
}
