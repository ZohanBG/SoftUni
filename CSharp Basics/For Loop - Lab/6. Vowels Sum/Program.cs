using System;

namespace _6._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                if (letter == 'a')
                {
                    sum = sum + 1;
                }
                else if (letter == 'e')
                {
                    sum = sum + 2;
                }
                else if (letter == 'i')
                {
                    sum = sum + 3;
                }
                else if (letter == 'o')
                {
                    sum = sum + 4;
                }
                else if (letter == 'u')
                {
                    sum = sum + 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
