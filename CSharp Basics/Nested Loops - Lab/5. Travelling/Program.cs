using System;

namespace _5._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double budget = double.Parse(Console.ReadLine());
                double savings = 0;
                while (budget > savings)
                {
                    double vnoska = double.Parse(Console.ReadLine());
                    savings += vnoska;
                }
                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
