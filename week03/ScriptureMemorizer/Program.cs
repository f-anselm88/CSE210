using System;

class Program
{
    // Creativity / exceeding requirements:
    // 1. Words are chosen at random only from those not already hidden
    //    (stretch challenge), so each keypress reveals meaningful progress.
    // 2. The program loads a library of scriptures from scriptures.txt
    //    and selects one at random each run, rather than using a single
    //    hardcoded scripture.
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary("scriptures.txt");
        var scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress enter to continue or type 'quit' to end.");
            var input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}