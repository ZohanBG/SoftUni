using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            Func<int, int> aritmeticCommand = num => num;
            Action<int[]> print = num => Console.WriteLine(string.Join(" ",num));
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        aritmeticCommand = num => num + 1;
                        numbers = numbers.Select(aritmeticCommand).ToArray();
                        break;
                    case "multiply":
                        aritmeticCommand = num => num * 2;
                        numbers = numbers.Select(aritmeticCommand).ToArray();
                        break;
                    case "subtract":
                        aritmeticCommand = num => num - 1;
                        numbers = numbers.Select(aritmeticCommand).ToArray();
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
