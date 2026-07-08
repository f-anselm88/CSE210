using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your grade percentage: ");
            int gradePercentage = Convert.ToInt32(Console.ReadLine());

            // Determine the letter grade
            string letter;
            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Determine the sign based on the last digit
            int lastDigit = gradePercentage % 10;
            string sign;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }

            // Handle exceptional cases: no A+, no F+ or F-
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }
            if (letter == "F")
            {
                sign = "";
            }

            Console.WriteLine($"Your grade is: {letter}{sign}");

            // Determine pass/fail
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations, you passed the course!");
            }
            else
            {
                Console.WriteLine("You did not pass this time, but keep working hard for next time!");
            }
        }
    }
}