using System;
using System.Collections.Generic;

public class Video
{
    // Member variables
    public string _title { get; set; }
    public string _author { get; set; }
    public int _lengthSeconds { get; set; }
    
    // A list to hold Comment objects
    private List<Comment> _comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _lengthSeconds = length;
    }

    // Method to add a comment to the list
    public void AddComment(Comment newComment)
    {
        _comments.Add(newComment);
    }

    // Method to return the number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // method to get the actual list for display
    public List<Comment> GetComments()
    {
        return _comments;
    }
}