using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        List<int> numberList = new List<int>();

        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        Console.Write("Enter a list of numbers, type 0 when finished.");
        bool zero = false;
        while (!zero)
        {
            Console.Write("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
            numberList.Add(number);

            if (number == 0)
            {
                zero = true;
            }

        }
        // for (int i = 0; i < numberList.Count; i++)
        // {
        //     Console.WriteLine(numberList[i]);
        // }
        // This just prints out all the integers in the list

        int sum0fAllNumbers = numberList.Sum();
        Console.WriteLine($"The sum of all numbers is: {sum0fAllNumbers}");

        float averageOfAllNumbers = ((float)sum0fAllNumbers/(numberList.Count - 1));
        //int averageOfAllNumbers = (sumOfAllNumbers / (numberList.Count - 1));
        Console.WriteLine($"The average of all numbers is: {averageOfAllNumbers}");

        int largestNumber = numberList.Max();
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}