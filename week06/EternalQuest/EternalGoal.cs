namespace EternalQuest;

// A goal that repeats indefinitely and is never marked complete,
// e.g. "Read Scriptures" -- earns points every time it is recorded.
public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) -- {Points} pts each time, recorded {_timesRecorded}x";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points},{_timesRecorded}";
    }
}
