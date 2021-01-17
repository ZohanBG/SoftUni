using System;

namespace _7._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double speed = double.Parse(Console.ReadLine());
            double ivanRecoredBeforeSlowed = lenght * speed;
            double slowed = Math.Floor(lenght / 15) * 12.5;
            double ivanRecord = ivanRecoredBeforeSlowed + slowed;
            if (ivanRecord < record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {ivanRecord:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(ivanRecord - record):f2} seconds slower.");
            }
        }
    }
}
