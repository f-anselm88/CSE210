using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    // Stretch requirement: only selects from words not already hidden,
    // so every prompt hides new words instead of possibly re-selecting
    // words that are already blank.
    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        var toHide = visibleWords.OrderBy(_ => random.Next()).Take(numberToHide);

        foreach (var word in toHide)
        {
            word.Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }
}