using System;

public class Comment
{
    // Member variables using Properties
    public string _name { get; set; }
    public string _text { get; set; }

    // Constructor to make creating comments easier
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
}