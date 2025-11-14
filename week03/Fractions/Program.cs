using System;

// This is the main entry point for your application.
public class Program
{
    public static void Main(string[] args)
    {
        // --- Verification 1: Constructors and Representations (Sample Output) ---
        // This section creates fractions using all constructors and
        // displays their string and decimal representations as per the sample.

        Console.WriteLine("--- Testing Constructors and Representations ---");

        // 1. Test default constructor: new Fraction()
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString()); // Expected: 1/1
        Console.WriteLine(f1.GetDecimalValue());   // Expected: 1

        // 2. Test single-parameter constructor: new Fraction(5)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString()); // Expected: 5/1
        Console.WriteLine(f2.GetDecimalValue());   // Expected: 5

        // 3. Test two-parameter constructor: new Fraction(3, 4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString()); // Expected: 3/4
        Console.WriteLine(f3.GetDecimalValue());   // Expected: 0.75

        // 4. Test another two-parameter constructor: new Fraction(1, 3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString()); // Expected: 1/3
        Console.WriteLine(f4.GetDecimalValue());   // Expected: 0.3333...

        // --- Verification 2: Getters and Setters ---
        // This section explicitly tests the Get/Set methods as requested.

        Console.WriteLine("\n--- Testing Getters and Setters ---");
        
        // Create an instance (e.g., 6/7 from your instructions, though any fraction works)
        Fraction f5 = new Fraction(6, 7);
        Console.WriteLine($"Original fraction: {f5.GetFractionString()}"); // Expected: 6/7

        // Use setters to change the values
        f5.SetTop(10);
        f5.SetBottom(11);

        // Use getters to retrieve the new values
        int newTop = f5.GetTop();
        int newBottom = f5.GetBottom();

        // Display the retrieved values
        Console.WriteLine($"New fraction after Set/Get: {newTop}/{newBottom}"); // Expected: 10/11
    }
}