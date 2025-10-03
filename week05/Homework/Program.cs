using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        var app = new MindfulnessApp();
        app.Run();
    }
    
    // Add missing ListingActivity class
    class ListingActivity : Activity
    {
        private static readonly List<string> prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    
        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }
    
        protected override void PerformActivity()
        {
            var rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();
    
            List<string> responses = new();
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                if (Console.KeyAvailable)
                {
                    string response = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        responses.Add(response);
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine($"You listed {responses.Count} items!");
        }
    
        private static void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}

internal class NewBaseType
{
    protected readonly List<Activity> activities;

    public NewBaseType(List<Activity> activities)
    {
        this.activities = activities;
    }

    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            int choice = GetMenuChoice();

            if (choice == 0)
                break;

            if (choice > 0 && choice <= activities.Count)
            {
                activities[choice - 1].Start();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    protected virtual void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Mindfulness App");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("0. Exit");
    }

    protected virtual int GetMenuChoice()
    {
        Console.Write("Enter your choice: ");
        return int.Parse(Console.ReadLine());
    }
}

class MindfulnessApp : NewBaseType
{
    public MindfulnessApp() : base(new List<Activity>
    {
        new BreathingActivity(),
        new ReflectionActivity(),
        new ListingActivity()
    })
    {
    }
}

abstract class Activity(string name, string description)
{
    protected string name = name;
    protected string description = description;
    protected int duration;

    public void Start()
    {
        DisplayStartingMessage();
        SetDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        PerformActivity();
        DisplayEndingMessage();
    }

    protected abstract void PerformActivity();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {name}.");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
    }

    protected void SetDuration()
    {
        int input;
        Console.Write("How long, in seconds, would you like for your session? ");
        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
        {
            Console.Write("Please enter a valid positive number of seconds: ");
        }
        duration = input;
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {duration} seconds of the {name}.");
        ShowSpinner(3);
    }

    protected static void ShowSpinner(int seconds)
    {
        var spinnerFrames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string frame = spinnerFrames[i % spinnerFrames.Count];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }
}

// Add missing BreathingActivity class
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }
    }

    private static void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

// Add missing ReflectionActivity class
class ReflectionActivity : Activity
{
    private static readonly List<string> prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        var rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int questionIndex = 0;
        while (DateTime.Now < endTime && questionIndex < questions.Count)
        {
            Console.Write(questions[questionIndex] + " ");
            ShowSpinner(5);
            Console.WriteLine();
            questionIndex++;
        }
    }
}

