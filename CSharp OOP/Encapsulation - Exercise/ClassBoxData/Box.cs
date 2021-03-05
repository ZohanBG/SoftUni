using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        {
            get => length;
            private set
            {
                IsInvalidException(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                IsInvalidException(value, nameof(Width));
                width = value;
            }
        }

        private double Height 
        {
            get => height;
            set
            {
                IsInvalidException(value, nameof(Height));
                height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double CalculateVolume()
        {
            return Length * Width * Height;
        }

        private void IsInvalidException(double value, string type)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }
        }
    }
}
