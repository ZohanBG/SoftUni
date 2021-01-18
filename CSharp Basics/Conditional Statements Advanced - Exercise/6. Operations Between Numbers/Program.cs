using System;

namespace _6._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string typeOfOperation = Console.ReadLine();
            double result = 0;
            double ostatuk = 0;
            string evenOrOdd = "";
            if (typeOfOperation == "+")
            {
                result = n1 + n2;
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{n1} {typeOfOperation} {n2} = {result} - {evenOrOdd}");
            }
            else if (typeOfOperation == "-")
            {
                result = n1 - n2;
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{n1} {typeOfOperation} {n2} = {result} - {evenOrOdd}");
            }
            else if (typeOfOperation == "*")
            {
                result = n1 * n2;
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{n1} {typeOfOperation} {n2} = {result} - {evenOrOdd}");
            }
            else if (typeOfOperation == "/")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {result:f2}");
                }
            }
            else if (typeOfOperation == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    ostatuk = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {ostatuk}");
                }
            }
        }
    }
}
