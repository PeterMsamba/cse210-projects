using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract method: derived classes must determine how to record an event
    // Returns the points earned from this specific event
    public abstract int RecordEvent();

    // Abstract method: check if the goal is fully complete
    public abstract bool IsComplete();

    // Virtual method: can be overridden if detailed string needs to change (e.g. Checklist)
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Abstract method: strictly for saving to file
    public abstract string GetStringRepresentation();
    
    // Getter for the name (useful for the manager)
    public string GetName()
    {
        return _shortName;
    }
}