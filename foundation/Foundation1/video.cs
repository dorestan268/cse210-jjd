using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Suggestion> _suggestions { get; set;}

    public Video()
    {
        _suggestions = new List<Suggestion>();
    }

    public void AddSuggestion(Suggestion suggestion)
    {
        _suggestions.Add(suggestion);
    }

    public int GetSuggestionCount()
    {
        return _suggestions.Count;
    }


    public List<Suggestion> GetSuggestions(){
        return _suggestions;
    }
}

