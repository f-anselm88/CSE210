using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create first video and its comments
        Video video1 = new Video("Building a Portfolio Website", "DevWithAnselm", 612);
        video1.AddComment(new Comment("Maria K.", "This helped me structure my own portfolio!"));
        video1.AddComment(new Comment("James T.", "Clear explanation of Flexbox vs Grid."));
        video1.AddComment(new Comment("Priya S.", "Subscribed, more content like this please."));

        // Create second video and its comments
        Video video2 = new Video("Intro to C# Classes", "CodeCraft Academy", 845);
        video2.AddComment(new Comment("Liam O.", "Finally understand encapsulation now."));
        video2.AddComment(new Comment("Grace N.", "Great pacing, not too fast."));
        video2.AddComment(new Comment("Tomas R.", "Can you cover interfaces next?"));
        video2.AddComment(new Comment("Aisha M.", "Rewatched this twice, very clear."));

        // Create third video and its comments
        Video video3 = new Video("Namibian Tech Scene 2026", "WindhoekDevs", 1023);
        video3.AddComment(new Comment("Ndara P.", "Great to see local tech getting coverage."));
        video3.AddComment(new Comment("Kevin B.", "Where can I find the meetup schedule?"));
        video3.AddComment(new Comment("Selma F.", "Loved the interview segment."));

        // Create fourth video and its comments
        Video video4 = new Video("REST APIs Explained Simply", "ByteSize Learning", 734);
        video4.AddComment(new Comment("Owen D.", "Best explanation I've found on this topic."));
        video4.AddComment(new Comment("Chidi A.", "The diagrams really helped."));
        video4.AddComment(new Comment("Rita V.", "Can you do a follow-up on GraphQL?"));

        // Store all videos in a single list
        List<Video> videos = new List<Video>
        {
            video1, video2, video3, video4
        };

        // Iterate through the videos and display their details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}