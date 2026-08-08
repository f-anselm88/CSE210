namespace EternalQuest;

// Owns the collection of goals and the player's overall progress (score
// and level). Contains the interactive menu loop that drives the console
// experience, and handles saving/loading the full state to a text file.
public class GoalManager
{
    private const int PointsPerLevel = 1000;

    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye! Keep working toward your Eternal Quest.");
                    break;
                default:
                    Console.WriteLine("That's not a valid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void DisplayPlayerInfo()
    {
        int level = GetLevel();
        int pointsIntoLevel = _score % PointsPerLevel;
        Console.WriteLine("=====================================");
        Console.WriteLine($"Score: {_score} pts   |   Level {level}   ({pointsIntoLevel}/{PointsPerLevel} to next level)");
        Console.WriteLine("=====================================");
    }

    private int GetLevel() => (_score < 0 ? 0 : _score / PointsPerLevel) + 1;

    private void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal      (one-time goal)");
        Console.WriteLine("  2. Eternal Goal      (repeats forever)");
        Console.WriteLine("  3. Checklist Goal   (repeat N times for a bonus)");
        Console.WriteLine("  4. Negative Goal     (a habit you're trying to quit)");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = (Console.ReadLine() ?? string.Empty).Trim();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? string.Empty;

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadInt();

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for completion? ");
                int target = ReadInt();
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = ReadInt();
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("That's not a valid goal type. No goal was created.");
                return;
        }

        Console.WriteLine("Goal created!");
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create one from the main menu!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create one from the main menu!");
            return;
        }

        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = ReadInt() - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That's not a valid goal number.");
            return;
        }

        int levelBefore = GetLevel();
        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;
        int levelAfter = GetLevel();

        if (pointsEarned >= 0)
        {
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine($"Recorded. You lost {-pointsEarned} points -- let's do better next time.");
        }

        if (_goals[index].IsComplete())
        {
            Console.WriteLine("This goal is now complete!");
        }

        if (levelAfter > levelBefore)
        {
            Console.WriteLine($"*** LEVEL UP! You are now Level {levelAfter}! ***");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for saving your goals? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for loading your goals? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Could not find a file named '{filename}'.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            Console.WriteLine("That file is empty.");
            return;
        }

        _goals = new List<Goal>();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string goalType = parts[0];
            string[] data = parts[1].Split(',');

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]),
                        int.Parse(data[4]), int.Parse(data[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded!");
    }

    private int ReadInt()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Please enter a whole number: ");
        }
        return result;
    }
}
