using System;

// Swimming activity class (lap pool is 50 meters)
public class Swimming : Activity
{
    // Specific attribute
    private int _numberOfLaps;

    // Constant for the length of a lap in meters
    private const int LapLengthMeters = 50;
    // Constant for conversion from meters to kilometers
    private const int MetersPerKm = 1000;

    // Constructor
    public Swimming(DateTime date, int durationMinutes, int numberOfLaps)
        : base(date, durationMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    // Method Overriding for Distance: Distance (km) = swimming laps * 50 / 1000
    public override double GetDistance()
    {
        return (double)_numberOfLaps * LapLengthMeters / MetersPerKm;
    }

    // Method Overriding for Speed: Speed (kph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        // Calculation uses the distance determined by GetDistance()
        double distance = GetDistance();
        // Safe division check
        if (DurationMinutes == 0) return 0;
        return (distance / DurationMinutes) * 60;
    }

    // Method Overriding for Pace: Pace (min/km) = minutes / distance
    public override double GetPace()
    {
        // Calculation uses the distance determined by GetDistance()
        double distance = GetDistance();
        // Safe division check
        if (distance == 0) return 0;
        return (double)DurationMinutes / distance;
    }
}