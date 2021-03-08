using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                if (data.Length == 4)
                {
                    buyers.Add(data[0], new Citizen(data[0], int.Parse(data[1]), data[2], data[3]));
                }
                else
                {
                    buyers.Add(data[0], new Rebel(data[0], int.Parse(data[1]), data[2]));
                }
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (buyers.ContainsKey(input))
                {
                    buyers[input].BuyFood();
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(x=>x.Value.Food));
        }
    }
}
