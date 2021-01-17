using System;

namespace _8._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int animals = int.Parse(Console.ReadLine());
            double dogfood = dogs * 2.5;
            int animalfood = animals * 4;
            Console.WriteLine($"{dogfood + animalfood} lv.");
        }
    }
}
