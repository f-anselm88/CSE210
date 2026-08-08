namespace EternalQuest;

// Abstract base class that defines the shared contract and shared state
// for every kind of goal in the program. Concrete goal types (SimpleGoal,
// EternalGoal, ChecklistGoal, NegativeGoal) inherit from this class and
// override the abstract members to provide their own behavior.
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Protected properties expose shared state to derived classes without
    // making the backing fields public (encapsulation).
    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    // Records that the goal was worked on / accomplished and returns the
    // number of points earned (can be negative for NegativeGoal).
    public abstract int RecordEvent();

    // Whether the goal is fully finished. Eternal and Negative goals are
    // never "complete" by design.
    public abstract bool IsComplete();

    // Human-readable line used when listing goals to the user, e.g.
    // "[X] Run a Marathon (Complete a marathon) -- 1000 pts"
    public abstract string GetDetailsString();

    // Serialized form used for saving to disk. Each derived class prefixes
    // the line with its own type name so it can be reconstructed on load.
    public abstract string GetStringRepresentation();
}
