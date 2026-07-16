using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScriptureLibrary
{
    private readonly List<Scripture> _scriptures = new List<Scripture>();

    public ScriptureLibrary(string filePath)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Expected format: Book|Chapter|Verse[-EndVerse]|Text
            var parts = line.Split('|');
            var book = parts[0];
            var chapter = int.Parse(parts[1]);
            var verseParts = parts[2].Split('-');
            var text = parts[3];

            Reference reference = verseParts.Length == 2
                ? new Reference(book, chapter, int.Parse(verseParts[0]), int.Parse(verseParts[1]))
                : new Reference(book, chapter, int.Parse(verseParts[0]));

            _scriptures.Add(new Scripture(reference, text));
        }
    }

    public Scripture GetRandomScripture()
    {
        var random = new Random();
        return _scriptures[random.Next(_scriptures.Count)];
    }
}