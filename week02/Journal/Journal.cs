using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    /// <summary>
    /// Manages the full collection of journal entries: adding new ones,
    /// displaying them, and saving/loading the collection to a CSV file.
    /// This class knows nothing about the console UI — that separation
    /// keeps it reusable (e.g., in a future web or mobile front end).
    /// </summary>
    public class Journal
    {
        private readonly List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("The journal is empty. Write your first entry!");
                return;
            }

            foreach (Entry entry in _entries)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(entry);
            }
        }

        /// <summary>
        /// Saves every entry to a CSV file. Overwrites any existing file
        /// at the given path.
        /// </summary>
        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                writer.WriteLine("Date,Mood,Prompt,Response");
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToCsvLine());
                }
            }
        }

        /// <summary>
        /// Loads entries from a CSV file, replacing whatever is
        /// currently in the journal. Skips the header row.
        /// </summary>
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File not found: {filename}");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            for (int i = 1; i < lines.Length; i++) // skip header row
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                _entries.Add(Entry.FromCsvLine(lines[i]));
            }
        }
    }
}
