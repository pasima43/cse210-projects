using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Console.Write("what is the magic number?");
        string rawMagicNumber = Console.ReadLine();
        int magicNumber = int.Parse(rawMagicNumber);
        bool isGuesseCorrect = false;
        while (!isGuesseCorrect)
        {
            Console.Write("what is your guess?");
            string rawGuess = Console.ReadLine();
            int guess = int.Parse(rawGuess);

            if (magicNumber > guess)
            {
                Console.WriteLine("try higher");
            }
            else if (magicNumber > guess)
            {
                Console.WriteLine("too lower");
            }
            else
            {
                Console.WriteLine("Correct! you got it!");
                isGuesseCorrect = true;
            }
        }
        
    }
}