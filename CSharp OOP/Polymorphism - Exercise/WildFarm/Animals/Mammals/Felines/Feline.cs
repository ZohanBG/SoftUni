using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, 
            double weight,  
            HashSet<string> allowedFoods, 
            double weightModifire, 
            string livingRegion,
            string breed) 
            : base(name, weight, allowedFoods, weightModifire, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
