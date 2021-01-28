using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using(StreamReader wordReader=new StreamReader("../../../words.txt"))
            {
                string currentRow = wordReader.ReadLine();
                while (currentRow != null)
                {
                    string[] input = currentRow.Split();
                    foreach (string word in input)
                    {
                        words.Add(word.ToLower(), 0);
                    }
                    currentRow = wordReader.ReadLine();
                }
            }
            using(StreamReader textReader=new StreamReader("../../../text.txt"))
            {
                string currentRow = textReader.ReadLine().ToLower();
                while (currentRow != null)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                        if(currentRow.Contains(words[i]))
                    }
                    currentRow = textReader.ReadLine().ToLower();
                }
            }
            words = words.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            using (StreamWriter writer=new StreamWriter("../../../output.txt"))
            {
                foreach (var word in words)
                {
                    writer.WriteLine($"{word.Key} -{word.Value}");
                }
            }
        }
    }
}
