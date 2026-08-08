namespace EternalQuest;

// A goal that is accomplished once, e.g. "Run a Marathon".
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return Points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        string marker = _isComplete ? "[X]" : "[ ]";
        return $"{marker} {Name} ({Description}) -- {Points} pts";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_isComplete}";
    }
}
