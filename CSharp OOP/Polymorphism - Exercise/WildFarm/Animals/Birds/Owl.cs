using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double weightModifire = 0.25;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        { 
            nameof(Meat)
        };

        public Owl(string name, 
            double weight,              
            double wingSize) 
            : base(name, weight, allowedFoods, weightModifire, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
