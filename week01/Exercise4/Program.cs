using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            int input;
            do
            {
                Console.Write("Enter number: ");
                input = int.Parse(Console.ReadLine());

                if (input != 0)
                {
                    numbers.Add(input);
                }
            } while (input != 0);

            // Core Requirement 1: Sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}");

            // Core Requirement 2: Average
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Core Requirement 3: Maximum
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge 1: Smallest positive number
            int? smallestPositive = null;
            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    if (smallestPositive == null || number < smallestPositive)
                    {
                        smallestPositive = number;
                    }
                }
            }

            if (smallestPositive != null)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch Challenge 2: Sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}