using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();
        string userName=PromptUserName();
        int userNumber=PromptUserNumber();
        int square=SquareNumber(userNumber);

        DisplayMessage(userName, square);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int favNum = int.Parse(Console.ReadLine());
            return favNum;
        }
        static int SquareNumber(int userNumber)
        {
            int square=userNumber*userNumber;
            return square;

        }

        static void DisplayMessage(string userName, int square)
        {
            Console.WriteLine($"Your username is {userName}, and your favorite number squared is {square}");
        }
        

        
        
    
        

    }
}