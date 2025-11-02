using System;
/*
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
    }
}
*/

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your surname? ");
        string surname = Console.ReadLine();

        Console.WriteLine($"Your name is {surname}, {firstName} {surname}.");
    }
}