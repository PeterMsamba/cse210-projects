public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Always returns points, never marks as complete
        return int.Parse(_points);
    }

    public override bool IsComplete()
    {
        // Eternal goals are never "complete"
        return false;
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal:Name,Description,Points
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}