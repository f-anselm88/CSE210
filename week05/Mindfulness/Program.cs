using System;
using System.Collections.Generic;

/*
 * Ways this program exceeds the core requirements:
 *
 * 1. Breathing animation: instead of a flat countdown, the breathing cue
 *    grows and shrinks with dots to visually mirror an inhale/exhale.
 *
 * 2. No-repeat reflection questions: ReflectingActivity draws from a
 *    shrinking pool of unused questions so none repeats until every
 *    question has been asked at least once in the session.
 *
 * 3. Session log: the program keeps an in-memory count of how many times
 *    each activity has been completed during the current run, viewable
 *    from the menu (option 4) and printed on exit.
 */
public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, int> sessionLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 }
        };

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. View Session Log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    sessionLog["Breathing"]++;
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    sessionLog["Reflecting"]++;
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    sessionLog["Listing"]++;
                    break;
                case "4":
                    PrintSessionLog(sessionLog);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Here's a summary of your session:");
        PrintSessionLog(sessionLog);
        Console.WriteLine("Thanks for taking time for mindfulness today!");
    }

    private static void PrintSessionLog(Dictionary<string, int> sessionLog)
    {
        Console.WriteLine();
        foreach (KeyValuePair<string, int> entry in sessionLog)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
        }
    }
}
