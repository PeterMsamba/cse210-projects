public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) 
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        int pointsEarned = 0;

        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            pointsEarned = int.Parse(_points);

            if (_amountCompleted == _target)
            {
                pointsEarned += _bonus;
            }
        }
        
        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        // Override to show progress count: [ ] Name (Desc) -- Currently completed: 2/5
        string baseString = base.GetDetailsString();
        return $"{baseString} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal:Name,Description,Points,Bonus,Target,AmountCompleted
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }

    // Helper for loading
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
}