using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.WriteLine("what is your first name?");
        string firstName = Console.ReadLine();
        Console.WriteLine("what is your last name?");
        string lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {firstName} {lastName}, {firstName} {lastName}.");
    }   
}