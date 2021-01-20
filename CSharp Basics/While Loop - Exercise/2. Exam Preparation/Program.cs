using System;

namespace _2._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFailiures = int.Parse(Console.ReadLine());
            int failedTimes = 0;
            int problems = 0;
            double gradesSum = 0;
            string lastProblem = "";
            bool isFailed = true;
            while (failedTimes < maxFailiures)
            {
                string problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failedTimes++;
                }
                gradesSum += grade;
                problems++;
                lastProblem = problemName;
            }
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {failedTimes} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {gradesSum / problems:f2}");
                Console.WriteLine($"Number of problems: {problems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
