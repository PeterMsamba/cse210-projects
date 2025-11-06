using System;

class Program
{
    static void Main(string[] args)
    {
        // Displaying a welcome message
        DisplayWelcome();

        // User name
        string userName = PromptUserName();

        // User favorite number
        int userNumber = PromptUserNumber();

        // Calculating the square of the favarite number
        int squaredNumber = SquareNumber(userNumber);

        // Display the result
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        
       if (int.TryParse(Console.ReadLine(), out int number))
        {
            return number;
        }
        else
        {
            // VAnvalide input
            Console.WriteLine("Invalid number entered. Using 0 as a default.");
            return 0;
        }
    }

    static int SquareNumber(int number)
    {
        // Return the number multiplied by itself
        return number * number;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}