using System;

namespace _6._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();
            double area = 1;
            if (shape == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                area = squareSide * squareSide;
            }
            else if (shape == "rectangle")
            {
                double rectangleSideA = double.Parse(Console.ReadLine());
                double rectangleSideB = double.Parse(Console.ReadLine());
                area = rectangleSideA * rectangleSideB;
            }
            else if (shape == "circle")
            {
                double circleRadius = double.Parse(Console.ReadLine());
                area = circleRadius * circleRadius * Math.PI;
            }
            else if (shape == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double sideVis = double.Parse(Console.ReadLine());
                area = (side * sideVis) / 2;
            }
            Console.WriteLine($"{area:F3}");
        }
    }
}
