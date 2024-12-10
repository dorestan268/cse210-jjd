using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(wordText => new Word(wordText))
                     .ToList();
    }

    // Hide random words
    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        var wordsToHide = _words.Where(word => !word.IsHidden())
                                .OrderBy(word => random.Next())
                                .Take(numberToHide);

        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    // Get the display text of the scripture
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceText}\n{scriptureText}";
    }

    // Get a hint display text with the first letter of hidden words
    public string GetHintDisplayText()
    {
        return string.Join(" ", _words.Select(word => word.IsHidden() ? word.GetFirstLetterHint() : word.GetDisplayText()));
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
