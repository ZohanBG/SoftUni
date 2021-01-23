using System;
using System.Collections.Generic;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!chars.ContainsKey(currentChar))
                {
                    chars.Add(currentChar, 0);
                }
                chars[currentChar]++;
            }
            foreach (var currentChar in chars)
            {
                Console.WriteLine($"{currentChar.Key}: {currentChar.Value} time/s");
            }
        }
    }
}
