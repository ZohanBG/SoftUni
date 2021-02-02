using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> filter = w => char.IsUpper(w[0]);
            words = words.Where(filter).ToArray();
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
