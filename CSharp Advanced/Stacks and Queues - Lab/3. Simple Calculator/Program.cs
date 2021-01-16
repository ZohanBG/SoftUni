using System;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> equasion = new Stack<string>();
            for (int i = input.Length-1; i >=0; i--)
            {
                equasion.Push(input[i]);
            }
            while (equasion.Count > 1)
            {
                int firstNum = int.Parse(equasion.Pop());
                string sign = equasion.Pop();
                int secondNum = int.Parse(equasion.Pop());
                if (sign == "+")
                {
                    equasion.Push((firstNum + secondNum).ToString());
                }
                else if (sign=="-")
                {
                    equasion.Push((firstNum - secondNum).ToString());
                }
            }
            Console.WriteLine(equasion.Pop());
        }
    }
}
