//Creativity: Library of scriptures
using System;
using System.Collections.Generic;
public class ScriptureLibrary
{
    private List<Scripture> _library;
    private Random _random;

    /// Constructor
    public ScriptureLibrary()
    {
        _library = new List<Scripture>();
        _random = new Random();

        Reference ref1 = new Reference("Proverbs", 3, 5, 6);
        string text1 = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        _library.Add(new Scripture(ref1, text1));

        Reference ref2 = new Reference("John", 3, 16);
        string text2 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        _library.Add(new Scripture(ref2, text2));
        
        Reference ref3 = new Reference("1 Corinthians", 10, 13);
        string text3 = "There hath no temptation taken you but such as is common to man: but God is faithful, who will not suffer you to be tempted above that ye are able; but will with the temptation also make a way to escape, that ye may be able to bear it.";
        _library.Add(new Scripture(ref3, text3));
    }

    public Scripture GetRandomScripture()
    {
        if (_library.Count == 0)
        {
            throw new InvalidOperationException("The scripture library is empty.");
        }

        int index = _random.Next(0, _library.Count);
        return _library[index];
    }
}