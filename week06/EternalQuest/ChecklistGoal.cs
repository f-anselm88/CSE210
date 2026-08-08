namespace EternalQuest;

// A goal that must be accomplished a set number of times before it counts
// as complete, e.g. "Attend the Temple 10 Times". Awards points each time,
// plus a bonus once the target count is reached.
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }

        if (_amountCompleted == _target)
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string marker = IsComplete() ? "[X]" : "[ ]";
        return $"{marker} {Name} ({Description}) -- Completed {_amountCompleted}/{_target} times, " +
               $"{Points} pts each, {_bonus} pt bonus on completion";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_target},{_bonus},{_amountCompleted}";
    }
}
