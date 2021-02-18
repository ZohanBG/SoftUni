using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> bombEffects = new Queue<int>(input);

            List<int> bombCasing = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;

            while ((bombCasing.Count > 0 && bombEffects.Count > 0) && (smokeCount < 3 || cherryCount < 3 || daturaCount < 3))
            {
                int sum = bombEffects.Peek() + bombCasing[bombCasing.Count - 1];
                if (sum == 40)
                {
                    daturaCount++;
                    bombEffects.Dequeue();
                    bombCasing.RemoveAt(bombCasing.Count - 1);
                }
                else if (sum==60)
                {
                    cherryCount++;
                    bombEffects.Dequeue();
                    bombCasing.RemoveAt(bombCasing.Count - 1);
                }
                else if (sum == 120)
                {
                    smokeCount++;
                    bombEffects.Dequeue();
                    bombCasing.RemoveAt(bombCasing.Count - 1);
                }
                else
                {
                    bombCasing[bombCasing.Count - 1] -= 5;
                }
            }

            if (smokeCount < 3 || cherryCount < 3 || daturaCount < 3)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");

        }
    }
}
