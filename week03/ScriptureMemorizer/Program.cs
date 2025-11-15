using System;

class Program
{
    static void Main(string[] args)
    {
        //Initialize the library and select a random scripture
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();
        
        // Define how many words to hide each time
        int wordsToHidePerTurn = 3; 

        // loop
        while (true)
        {
            // Display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine(); 

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Program ending.");
                break;
            }

            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine();

            // Handle user input
            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                // Hides random unhidden words
                scripture.HideRandomWords(wordsToHidePerTurn);
            }
        }
    }
}