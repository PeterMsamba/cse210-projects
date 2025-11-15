using System;

/// Represents a single word in the scripture.
/// Tracks the text of the word and whether it is hidden.
public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    //Public Methods:Hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    /// Checks if the word is currently hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// Returns the display text for the word.
    /// If hidden, returns underscores. If visible, returns the word text.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Returns a string of underscores matching the word length
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}