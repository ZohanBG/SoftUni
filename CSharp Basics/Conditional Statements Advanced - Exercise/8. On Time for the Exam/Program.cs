using System;

namespace _8._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfComing = int.Parse(Console.ReadLine());
            int minutesOfComing = int.Parse(Console.ReadLine());
            int examHour = hourOfExam * 60 + minutesOfExam;
            int comingHour = hourOfComing * 60 + minutesOfComing;
            int razlika = 0;
            int minutes = 0;
            int hour = 0;
            if (comingHour > examHour)
            {
                Console.WriteLine("Late");
                razlika = comingHour - examHour;
                if (razlika < 60)
                {
                    Console.WriteLine($"{razlika} minutes after the start");
                }
                else
                {
                    minutes = razlika % 60;
                    hour = (razlika - minutes) / 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hour}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hour}:{minutes} hours after the start");
                    }
                }
            }
            else if ((examHour - comingHour) >= 0 && (examHour - comingHour) <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{examHour - comingHour} minutes before the start");
            }
            else if ((examHour - comingHour) > 30)
            {
                Console.WriteLine("Early");
                razlika = examHour - comingHour;
                if (razlika < 60)
                {
                    Console.WriteLine($"{razlika} minutes before the start");
                }
                else
                {
                    minutes = razlika % 60;
                    hour = (razlika - minutes) / 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hour}:0{minutes} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hour}:{minutes} hours before the start");
                    }
                }
            }
        }
    }
}
