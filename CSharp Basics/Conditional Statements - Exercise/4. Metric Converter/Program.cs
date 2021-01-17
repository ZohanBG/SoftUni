using System;

namespace _4._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = double.Parse(Console.ReadLine());
            string nachalnaMernaEdinica = Console.ReadLine();
            string krainaMernaEdinica = Console.ReadLine();
            double newSize = 0;
            if (nachalnaMernaEdinica == "m")
            {
                if (krainaMernaEdinica == "cm")
                {
                    newSize = size * 100;
                }
                if (krainaMernaEdinica == "mm")
                {
                    newSize = size * 1000;
                }
            }
            else if (nachalnaMernaEdinica == "cm")
            {
                if (krainaMernaEdinica == "m")
                {
                    newSize = size / 100;
                }
                if (krainaMernaEdinica == "mm")
                {
                    newSize = size * 10;
                }
            }
            else if (nachalnaMernaEdinica == "mm")
            {
                if (krainaMernaEdinica == "m")
                {
                    newSize = size / 1000;
                }
                if (krainaMernaEdinica == "cm")
                {
                    newSize = size / 10;
                }
            }
            Console.WriteLine($"{newSize:f3}");
        }
    }
}
