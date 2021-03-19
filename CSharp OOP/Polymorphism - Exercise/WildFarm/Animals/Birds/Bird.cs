using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(
            string name, 
            double weight,  
            HashSet<string> allowedFoods, 
            double weightModifire,
            double wingSize) 
            : base(name, weight, allowedFoods, weightModifire)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
