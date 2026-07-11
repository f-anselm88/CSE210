using System;

namespace Journal
{
    // Notes on exceeding requirements (per assignment submission instructions):
    // 1. Entries are saved as proper CSV (quoted fields, escaped quotes/commas)
    //    so the file opens cleanly in Excel or Google Sheets, not just a
    //    custom delimiter.
    // 2. Each entry captures a "mood" tag alongside the response, giving the
    //    user a lightweight way to track emotional trends over time.
    // 3. Each entry reports a word count, calculated on demand rather than
    //    stored, to encourage reflection on how much detail was written.
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Load");
                Console.WriteLine("5. Exit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal, promptGenerator);
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("What is the filename? ");
                        journal.SaveToFile(Console.ReadLine());
                        Console.WriteLine("Journal saved.");
                        break;
                    case "4":
                        Console.Write("What is the filename? ");
                        journal.LoadFromFile(Console.ReadLine());
                        Console.WriteLine("Journal loaded.");
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Please try again.");
                        break;
                }
            }
        }

        private static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
        {
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine(prompt);
            Console.Write("> ");
            string response = Console.ReadLine();

            Console.Write("In one word, how are you feeling right now? ");
            string mood = Console.ReadLine();

            string date = DateTime.Now.ToShortDateString();
            Entry entry = new Entry(date, prompt, response, mood);
            journal.AddEntry(entry);
        }
    }
}