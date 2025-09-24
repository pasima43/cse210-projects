using System;
using System.Collections.Generic;
using System.Threading;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        CommentText = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos and add comments (same as before)
        Video video1 = new Video("Learning C#", "CodeMaster", 600);
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
        video1.AddComment(new Comment("User3", "Could you make more videos like this?"));
        videos.Add(video1);

        Video video2 = new Video("Cooking Italian Pasta", "ChefExtraordinaire", 480);
        video2.AddComment(new Comment("FoodLover", "Delicious recipe!"));
        video2.AddComment(new Comment("ItalianMamma", "Just like how we make it at home!"));
        video2.AddComment(new Comment("Beginner Cook", "Easy to follow, thank you!"));
        videos.Add(video2);

        Video video3 = new Video("Guitar Basics", "RockStar101", 720);
        video3.AddComment(new Comment("MusicFan", "Finally understood how to tune my guitar!"));
        video3.AddComment(new Comment("AspiringMusician", "Can you do an advanced tutorial next?"));
        video3.AddComment(new Comment("GuitarNewbie", "This helped me so much, thanks!"));
        videos.Add(video3);

        bool continuePlayback = true;

        while (continuePlayback)
        {
            foreach (Video video in videos)
            {
                Console.Clear();
                Console.WriteLine($"Now playing: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
                Console.WriteLine("\\nComments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
                }
                Console.WriteLine("\\nPress any key to continue to the next video, or 'Q' to quit.");
                
                // Simulate video playback
                for (int i = 0; i < video.LengthInSeconds; i++)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Q)
                        {
                            continuePlayback = false;
                            break;
                        }
                        break;
                    }
                    Thread.Sleep(1000); // Wait for 1 second
                    Console.Write(".");
                }

                if (!continuePlayback) break;
            }
        }

                Console.WriteLine("\nThank you for watching!");
            }
        }