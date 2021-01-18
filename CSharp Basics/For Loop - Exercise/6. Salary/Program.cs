using System;

namespace _6._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabbCount = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            for (int i = 0; i < tabbCount; i++)
            {
                string tabb = Console.ReadLine();
                if (tabb == "Facebook")
                {
                    salary -= 150;
                }
                else if (tabb == "Instagram")
                {
                    salary -= 100;
                }
                else if (tabb == "Reddit")
                {
                    salary -= 50;
                }
                else
                {
                    salary -= 0;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
