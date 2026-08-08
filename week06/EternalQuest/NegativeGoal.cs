namespace EternalQuest;

// CREATIVITY FEATURE: A goal for habits the user is trying to break rather
// than build, e.g. "Skipped Study Session". Recording an event on a
// NegativeGoal SUBTRACTS points instead of adding them. Like EternalGoal,
// it is never "complete" -- it just tracks how often the habit occurred.
public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return -Points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) -- -{Points} pts each time, happened {_timesRecorded}x";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{Name},{Description},{Points},{_timesRecorded}";
    }
}
