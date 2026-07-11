using System;

namespace Journal
{
    /// <summary>
    /// Represents a single journal entry: the date it was written,
    /// the prompt that inspired it, the user's response, and an
    /// optional mood tag. Demonstrates abstraction by exposing only
    /// what callers need (read-only properties) while hiding how the
    /// data is stored or formatted internally.
    /// </summary>
    public class Entry
    {
        public string Date { get; private set; }
        public string Prompt { get; private set; }
        public string Response { get; private set; }
        public string Mood { get; private set; }

        // Exceeds requirements: track response length so users can see
        // journaling trends (e.g., "you wrote 40 words today").
        public int WordCount => string.IsNullOrWhiteSpace(Response)
            ? 0
            : Response.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

        public Entry(string date, string prompt, string response, string mood)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
            Mood = mood;
        }

        public override string ToString()
        {
            return $"{Date}\nPrompt: {Prompt}\nMood: {Mood}\n{Response}\n" +
                   $"({WordCount} words)\n";
        }

        /// <summary>
        /// Serializes this entry as one CSV-safe line: date,mood,prompt,response.
        /// Fields are quoted and any internal quotes are escaped per RFC 4180,
        /// so the saved file can be opened directly in Excel or Google Sheets.
        /// </summary>
        public string ToCsvLine()
        {
            return string.Join(",", Escape(Date), Escape(Mood), Escape(Prompt), Escape(Response));
        }

        private static string Escape(string field)
        {
            if (field == null) field = string.Empty;
            bool needsQuoting = field.Contains(",") || field.Contains("\"") || field.Contains("\n");
            string escaped = field.Replace("\"", "\"\"");
            return needsQuoting ? $"\"{escaped}\"" : escaped;
        }

        /// <summary>
        /// Parses one CSV line (produced by ToCsvLine) back into an Entry.
        /// Handles quoted fields containing commas or escaped quotes.
        /// </summary>
        public static Entry FromCsvLine(string line)
        {
            var fields = ParseCsvFields(line);
            string date = fields.Count > 0 ? fields[0] : string.Empty;
            string mood = fields.Count > 1 ? fields[1] : string.Empty;
            string prompt = fields.Count > 2 ? fields[2] : string.Empty;
            string response = fields.Count > 3 ? fields[3] : string.Empty;
            return new Entry(date, prompt, response, mood);
        }

        private static System.Collections.Generic.List<string> ParseCsvFields(string line)
        {
            var fields = new System.Collections.Generic.List<string>();
            var current = new System.Text.StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else if (c == '"')
                    {
                        inQuotes = false;
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        fields.Add(current.ToString());
                        current.Clear();
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
            }
            fields.Add(current.ToString());
            return fields;
        }
    }
}
