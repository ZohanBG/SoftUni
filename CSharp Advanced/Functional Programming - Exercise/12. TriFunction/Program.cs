using System;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] people = Console.ReadLine().Split();
            Func<string, int, bool> filter = (word, lenghtSum) =>
              {
                  int sum = 0;
                  foreach (char ch in word)
                  {
                      sum += ch;
                  }
                  return lenghtSum <= sum;
              };
            foreach (var person in people)
            {
                if (filter(person, lenght))
                {
                    Console.WriteLine(person);
                    break;
                }
            }

        }
    }
}
