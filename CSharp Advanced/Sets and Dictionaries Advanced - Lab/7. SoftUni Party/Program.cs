using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                Match match = Regex.Match(input, @"([0-9]){1}\w{7}");
                if (match.Success)
                {
                    vips.Add(input);
                }
                else
                {
                    regulars.Add(input);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                Match match = Regex.Match(input, @"([0-9]){1}\w{7}");
                if (match.Success)
                {
                    vips.Remove(input);
                }
                else
                {
                    regulars.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(vips.Count+regulars.Count);
            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }
            foreach (var regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
