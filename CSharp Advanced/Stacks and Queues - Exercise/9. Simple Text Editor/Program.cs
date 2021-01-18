using System;
using System.Collections.Generic;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> changes = new Stack<string>();
            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "1":
                        changes.Push(text);
                        text += command[1];
                        break;
                    case "2":
                        changes.Push(text);
                        int lenght = int.Parse(command[1]);
                        text = text.Substring(0, text.Length - lenght);
                        break;
                    case "3":
                        int index = int.Parse(command[1]);
                        Console.WriteLine(text[index-1]);
                        break;
                    case "4":
                        text = changes.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
