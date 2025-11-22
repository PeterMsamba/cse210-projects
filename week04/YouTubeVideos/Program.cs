using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. A list to holds videos
        List<Video> videos = new List<Video>();

        // 2. Video #1 and add comments
        Video v1 = new Video("Trust in Christ, find peace.", "Mike", 600);
        v1.AddComment(new Comment("Alice", "Amen to that!"));
        v1.AddComment(new Comment("Bob", "so true"));
        v1.AddComment(new Comment("Charlie", "Praying for peace"));
        videos.Add(v1);

        // 3. Video #2 and add comments
        Video v2 = new Video("Psychology of people with No friends", "PsychoogyFucts", 950);
        v2.AddComment(new Comment("Dave", "Or maybe it's just how u feel more connected with urself"));
        v2.AddComment(new Comment("Eve", "Truly insightful"));
        v2.AddComment(new Comment("Frank", "In my case i'm too busy for them"));
        videos.Add(v2);

        // 4. Video #3 and add comments
        Video v3 = new Video("Your intelligence is Runnung your life (And you don't realise)", "SimpleMind", 1200);
        v3.AddComment(new Comment("Grace", "A smart person can take this advice and adapt"));
        v3.AddComment(new Comment("Heidi", "Overthing is killing me."));
        v3.AddComment(new Comment("Ivan", "100% agree, I feel most of the point in the video especially point number 1"));
        v3.AddComment(new Comment("Judy", "Watching this when i get bad grades."));
        videos.Add(v3);

        // 5. Iterate through the list of videos and display info
        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthSeconds} seconds");
            
            // Using the required method to get the count
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}"); 
            
            Console.WriteLine("Comments:");

            // Iterate through the comments of this specific video
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._name}: \"{comment._text}\"");
            }
            
        }
    }
}