using System;

// Base class for all activities
public abstract class Activity
{
    // Private attributes (Encapsulation)
    private DateTime _date;
    private int _durationMinutes; // Length of the activity in minutes

    // Constructor to initialize the shared attributes
    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    // Public getters for read-only access to base attributes
    public DateTime Date => _date;
    public int DurationMinutes => _durationMinutes;

    // Abstract methods to be overridden by derived classes for calculation
    // These methods declare the contract for getting activity-specific metrics.
    public abstract double GetDistance(); // Returns distance in kilometers (km)
    public abstract double GetSpeed();    // Returns speed in kilometers per hour (kph)
    public abstract double GetPace();     // Returns pace in minutes per kilometer (min/km)

    // Method to get a complete summary string
    // This is defined in the base class and uses the abstract methods.
    // It is generally available to all derived classes without needing an override.
    public virtual string GetSummary()
    {
        // Calculate metrics using the overridden methods from the derived class
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        string type = GetType().Name; // Gets the name of the derived class (e.g., "Running")

        // Format the date as "dd MMM yyyy"
        string dateString = _date.ToString("dd MMM yyyy");

        // Construct the summary string (using km/kph/min per km)
        return $"{dateString} {type} ({_durationMinutes} min) - " +
               $"Distance: {distance:F2} km, " +
               $"Speed: {speed:F2} kph, " +
               $"Pace: {pace:F2} min per km";
    }
}