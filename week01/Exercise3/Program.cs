using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int guessCount = 0;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I've picked a number between 1 and 100. Try to guess it!");

        while (guess != magicNumber)
        {
            Console.Write("Enter your guess (1-100): ");
            string guessInput = Console.ReadLine();
            
            if (!int.TryParse(guessInput, out guess))
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
                continue;
            }

            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {guessCount} attempts! The magic number was {magicNumber}.");
            }
        }
    }
}