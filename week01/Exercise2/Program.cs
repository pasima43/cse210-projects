using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.WriteLine("what was your grade in the class?");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        if (grade >= 90)
        {
            string letter = "A";
            Console.WriteLine($"You got an {letter} in the class congratulations!");

        }
        else if (grade >= 80)
        {
            string letter = "B";
            Console.WriteLine($"You got a {letter} in the class good job!");

        }
        else if (grade >= 70)
        {
            string letter = "C";
            Console.WriteLine($"You got a {letter} in the class you passed.");

        }
        else if (grade >= 60)
        {
            string letter = "D";
            Console.WriteLine($"You got a {letter} in the class you should probably retake it.");

        }
        else
        {
            string letter = "F";
            Console.WriteLine($"You got an {letter} in the class you failed and will have to retake it.");

        }
    }
}