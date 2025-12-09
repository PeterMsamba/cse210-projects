using System;

// Cycling activity class
public class Cycling : Activity
{
    // Specific attribute
    private double _speedKph; // Stored speed in kilometers per hour

    // Constructor
    public Cycling(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    // Method Overriding for Distance: Distance = (speed / 60) * minutes
    public override double GetDistance()
    {
        return (_speedKph / 60) * DurationMinutes;
    }

    // Method Overriding for Speed (Stored directly)
    public override double GetSpeed()
    {
        return _speedKph;
    }

    // Method Overriding for Pace: Pace = 60 / speed
    public override double GetPace()
    {
        // Safe division check
        if (_speedKph == 0) return 0;
        return 60 / _speedKph;
    }
}