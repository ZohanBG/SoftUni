using System;
using System.Collections.Generic;

namespace _8._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isGood = true;
            foreach (char item in input)
            {
                switch (item)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(item);
                        break;
                    case ')':
                        if (stack.Count == 0|| stack.Pop() != '(')
                        {
                            isGood = false;
                        }                      
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            isGood = false;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            isGood = false;
                        }
                        break;
                    default:
                        break;
                }
                if (!isGood)
                {
                    break;
                }
            }
            Console.WriteLine(isGood?"YES":"NO");
        }
    }
}
