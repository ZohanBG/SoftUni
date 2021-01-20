using System;

namespace _4._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepCounter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Going home")
                {
                    stepCounter += int.Parse(input);
                }
                else
                {
                    stepCounter += int.Parse(Console.ReadLine()); ;
                    break;
                }
                if (stepCounter >= 10000)
                {
                    break;
                }
            }
            if (stepCounter >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepCounter - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - stepCounter} more steps to reach goal.");
            }
        }
    }
}
