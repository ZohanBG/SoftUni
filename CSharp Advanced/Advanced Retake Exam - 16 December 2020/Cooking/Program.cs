using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading input
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> liquids = new Queue<int>(input);
            input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> ingredients = new List<int>(input);

            //Logic
            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int value = liquids.Peek() + ingredients[ingredients.Count-1];
                if (value == 25)
                {
                    breadCount++;
                    liquids.Dequeue();
                    ingredients.RemoveAt(ingredients.Count - 1);
                }
                else if (value == 50)
                {
                    cakeCount++;
                    liquids.Dequeue();
                    ingredients.RemoveAt(ingredients.Count - 1);
                }
                else if (value == 75)
                {
                    pastryCount++;
                    liquids.Dequeue();
                    ingredients.RemoveAt(ingredients.Count - 1);
                }
                else if (value == 100)
                {
                    fruitPieCount++;
                    liquids.Dequeue();
                    ingredients.RemoveAt(ingredients.Count - 1);
                }
                else
                {
                    liquids.Dequeue();
                    ingredients[ingredients.Count - 1] += 3;
                }
            }

            //Output

            if (breadCount > 0 && cakeCount > 0 && pastryCount > 0 && fruitPieCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                ingredients.Reverse();
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");

        }
    }
}
