using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double weightModifire = 0.40;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name,
            double weight,
            string livingRegion)
            : base(name, weight, allowedFoods, weightModifire, livingRegion)
        {

        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
