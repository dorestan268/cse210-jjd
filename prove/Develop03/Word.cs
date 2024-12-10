using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Words are visible by default
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the display text of the word
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    // Get the first letter of the word as a hint
    public string GetFirstLetterHint()
    {
        return _isHidden ? $"{_text[0]}____" : _text;
    }
}
