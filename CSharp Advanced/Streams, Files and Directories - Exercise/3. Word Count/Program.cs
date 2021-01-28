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
            string[] inputWords = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (string word in inputWords)
            {
                words.Add(word, 0);
            }
            string text = File.ReadAllText("../../../text.txt").ToLower();
            string[] wordsInText = text.Split(new string[] { "-", ",", ".", "!", "?", " ", Environment.NewLine }
            , StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in wordsInText)
            {
                if (words.ContainsKey(word))
                {
                    words[word]++;
                }
            }
            foreach (var word in words)
            {
                string line = $"{word.Key} - {word.Value}";
                File.AppendAllText("../../../actualResult.txt", line + Environment.NewLine);
            }
            words = words.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var word in words)
            {
                string line = $"{word.Key} - {word.Value}";
                File.AppendAllText("../../../expectedResult.txt", line + Environment.NewLine);
            }
        }
    }
}
