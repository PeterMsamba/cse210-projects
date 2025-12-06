public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return int.Parse(_points);
        }
        else
        {
            Console.WriteLine("You have already completed this goal!");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal:Name,Description,Points,IsComplete
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }

    // Helper to set completion status when loading from file
    public void SetComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }
}