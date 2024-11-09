using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

           
            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        

        
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        

        
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
