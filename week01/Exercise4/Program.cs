using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A list to store numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a series of numbers. Enter '0' when you are finished.");

        int inputNumber = -1;

        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // Error handling and conversion
            if (int.TryParse(input, out inputNumber))
            {
                // Check if the number is not equal to zero
                if (inputNumber != 0)
                {
                    // If it's not 0, add it to the list
                    numbers.Add(inputNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }

        } while (inputNumber != 0);

        Console.WriteLine($"You entered {numbers.Count} numbers.");
        
        if (numbers.Count > 0)
        {
            Console.WriteLine("Your list: " + string.Join(", ", numbers));
        }
    }
}