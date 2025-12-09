using System;

// Running activity class
public class Running : Activity
{
    // Specific attribute
    private double _distanceKm; // Stored distance in kilometers

    // Constructor
    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        _distanceKm = distanceKm;
    }

    // Method Overriding for Distance (Stored directly)
    public override double GetDistance()
    {
        return _distanceKm;
    }

    // Method Overriding for Speed: Speed (kph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        // Safe division check
        if (DurationMinutes == 0) return 0;
        return (_distanceKm / DurationMinutes) * 60;
    }

    // Method Overriding for Pace: Pace (min/km) = minutes / distance
    public override double GetPace()
    {
        // Safe division check
        if (_distanceKm == 0) return 0;
        return (double)DurationMinutes / _distanceKm;
    }
}