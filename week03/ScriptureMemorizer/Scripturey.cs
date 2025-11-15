using System;
using System.Collections.Generic;
using System.Linq; 

/// Represents a scripture, including its reference and text.
/// Manages hiding words and displaying the scripture.
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random(); // For picking random words

    /// Constructor. Initializes the scripture with its reference and text.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into words and create Word objects
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    /// Hides a specified number of random words that are not already hidden.
    public void HideRandomWords(int numberToHide)
    {
        // Find all words that are not currently hidden
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide; i++)
        {
            // If all words are hidden, stop trying
            if (unhiddenWords.Count == 0)
            {
                break;
            }

            // Pick a random index from the list of unhidden words
            int index = _random.Next(unhiddenWords.Count);
            
            // Hide the chosen word
            unhiddenWords[index].Hide();
            
            // Remove it from our temporary list so we don't pick it again this turn
            unhiddenWords.RemoveAt(index);
        }
    }

    /// Assembles and returns the full display text of the scripture,
    /// including the reference and all words
    public string GetDisplayText()
    {
        // Start with the reference
        string displayText = _reference.GetDisplayText() + " ";

        // Add each word's display text
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        // Trim trailing space
        return displayText.Trim();
    }

    /// Checks if all words in the scripture are hidden.
    public bool IsCompletelyHidden()
    {
        // Checks if every word's IsHidden() method returns true
        return _words.All(w => w.IsHidden());
    }
}