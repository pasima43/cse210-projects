class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good things in your life by listing as many items as you can in a certain area.")
    {
        // Optionally set name and description here if needed
    }

    public ListingActivity(string name, string description) : base(name, description)
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You may begin in:");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }
        Console.WriteLine($"You listed {count} items!");
    }
}

