using System;

namespace _8._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            int failedCounter = 0;
            double sum = 0;
            while (grade <= 12)
            {
                double rating = double.Parse(Console.ReadLine());
                if (rating >= 4)
                {
                    sum += rating;
                    grade++;

                }
                else
                {
                    failedCounter++;
                    if (failedCounter == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                }

            }
            if (grade > 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum / 12:f2}");
            }
        }
    }
}
